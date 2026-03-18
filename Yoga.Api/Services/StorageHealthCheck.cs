using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Yoga.Api.Services
{
    public class StorageHealthCheck : IHealthCheck
    {
        private readonly IFileStorageService _storageService;

        public StorageHealthCheck(IFileStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var healthy = await _storageService.CheckHealthAsync(cancellationToken);
            return healthy
                ? HealthCheckResult.Healthy("Storage reachable.")
                : HealthCheckResult.Unhealthy("Storage health check failed.");
        }
    }
}