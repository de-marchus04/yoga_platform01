using Microsoft.JSInterop;

namespace Yoga.Client.Services
{
    public class AdminHttpHandler : DelegatingHandler
    {
        private readonly IJSRuntime _js;
        private const string TokenKey = "yl-admin-token";

        public AdminHttpHandler(IJSRuntime js)
        {
            _js = js;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = await _js.InvokeAsync<string?>("localStorage.getItem", TokenKey);
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                }
            }
            catch
            {
                // JS interop may fail during prerendering — proceed without token
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
