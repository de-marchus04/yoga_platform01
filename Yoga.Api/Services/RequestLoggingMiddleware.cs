using System.Diagnostics;

namespace Yoga.Api.Services
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            var traceId = context.TraceIdentifier;

            context.Response.OnStarting(static state =>
            {
                var httpContext = (HttpContext)state;
                httpContext.Response.Headers["X-Trace-Id"] = httpContext.TraceIdentifier;
                return Task.CompletedTask;
            }, context);

            using (_logger.BeginScope(new Dictionary<string, object?>
            {
                ["TraceId"] = traceId,
                ["RequestMethod"] = context.Request.Method,
                ["RequestPath"] = context.Request.Path.Value,
                ["RemoteIp"] = context.Connection.RemoteIpAddress?.ToString()
            }))
            {
                try
                {
                    await _next(context);
                }
                finally
                {
                    stopwatch.Stop();

                    _logger.LogInformation(
                        "HTTP {Method} {Path} responded {StatusCode} in {ElapsedMs} ms",
                        context.Request.Method,
                        context.Request.Path.Value,
                        context.Response.StatusCode,
                        stopwatch.Elapsed.TotalMilliseconds);
                }
            }
        }
    }
}