using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Yoga.Api.Data;

namespace Yoga.Api.Services
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly AppDbContext _context;

        public DatabaseHealthCheck(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var canConnect = await _context.Database.CanConnectAsync(cancellationToken);
                if (!canConnect)
                {
                    return HealthCheckResult.Unhealthy("Database connection failed.");
                }

                return HealthCheckResult.Healthy("Database reachable.");
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("Database health check threw an exception.", ex);
            }
        }
    }
}