using Microsoft.AspNetCore.Http;

namespace Yoga.Api.Services
{
    public interface IFileStorageService
    {
        Task<FileStorageResult> SaveAsync(IFormFile file, string? folder = null, CancellationToken cancellationToken = default);
        Task DeleteAsync(string url, CancellationToken cancellationToken = default);
        Task<bool> CheckHealthAsync(CancellationToken cancellationToken = default);
        Task<FileAccessResult> GetReadAccessAsync(string url, bool isPrivate, TimeSpan? lifetime = null, CancellationToken cancellationToken = default);
    }

    public sealed record FileStorageResult(string Url, string StorageKey, long Size, string ContentType);
    public sealed record FileAccessResult(string Url, DateTimeOffset? ExpiresAt);
}