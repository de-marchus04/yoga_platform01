using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Yoga.Api.Options;

namespace Yoga.Api.Services
{
    public class LocalFileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _env;
        private readonly StorageOptions _options;

        public LocalFileStorageService(IWebHostEnvironment env, IOptions<StorageOptions> options)
        {
            _env = env;
            _options = options.Value;
        }

        public async Task<FileStorageResult> SaveAsync(IFormFile file, string? folder = null, CancellationToken cancellationToken = default)
        {
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            var fileName = $"{Guid.NewGuid()}{extension}";
            var relativeFolder = string.IsNullOrWhiteSpace(folder) ? string.Empty : folder.Trim().Trim('/');

            var rootPath = ResolveRootPath();
            var targetDirectory = string.IsNullOrWhiteSpace(relativeFolder)
                ? rootPath
                : Path.Combine(rootPath, relativeFolder.Replace('/', Path.DirectorySeparatorChar));

            Directory.CreateDirectory(targetDirectory);

            var absolutePath = Path.Combine(targetDirectory, fileName);
            await using (var stream = new FileStream(absolutePath, FileMode.Create))
            {
                await file.CopyToAsync(stream, cancellationToken);
            }

            var storageKey = string.IsNullOrWhiteSpace(relativeFolder)
                ? fileName
                : $"{relativeFolder}/{fileName}";

            var relativeUrl = CombineUrl(_options.PublicBaseUrl, storageKey);
            var publicUrl = string.IsNullOrWhiteSpace(_options.PublicHost)
                ? relativeUrl
                : $"{_options.PublicHost.TrimEnd('/')}{relativeUrl}";

            return new FileStorageResult(publicUrl, storageKey, file.Length, file.ContentType);
        }

        public Task DeleteAsync(string url, CancellationToken cancellationToken = default)
        {
            var storageKey = ResolveStorageKey(url);
            if (string.IsNullOrWhiteSpace(storageKey))
            {
                return Task.CompletedTask;
            }

            var absolutePath = Path.Combine(ResolveRootPath(), storageKey.Replace('/', Path.DirectorySeparatorChar));
            if (File.Exists(absolutePath))
            {
                File.Delete(absolutePath);
            }

            return Task.CompletedTask;
        }

        public async Task<bool> CheckHealthAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var rootPath = ResolveRootPath();
                Directory.CreateDirectory(rootPath);

                var probeFile = Path.Combine(rootPath, $".storage-health-{Guid.NewGuid():N}.tmp");
                await File.WriteAllTextAsync(probeFile, "ok", cancellationToken);
                File.Delete(probeFile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<FileAccessResult> GetReadAccessAsync(string url, bool isPrivate, TimeSpan? lifetime = null, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new FileAccessResult(url, null));
        }

        private string ResolveRootPath()
        {
            var configuredPath = _options.LocalRootPath.Replace('/', Path.DirectorySeparatorChar);
            return Path.IsPathRooted(configuredPath)
                ? configuredPath
                : Path.Combine(_env.ContentRootPath, configuredPath);
        }

        private string ResolveStorageKey(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }

            if (Uri.TryCreate(url, UriKind.Absolute, out var absoluteUri))
            {
                url = absoluteUri.AbsolutePath;
            }

            var publicBasePath = _options.PublicBaseUrl.TrimEnd('/');
            if (!url.StartsWith(publicBasePath, StringComparison.OrdinalIgnoreCase))
            {
                return string.Empty;
            }

            return url[publicBasePath.Length..].TrimStart('/');
        }

        private static string CombineUrl(string basePath, string storageKey)
        {
            var normalizedBase = string.IsNullOrWhiteSpace(basePath) ? string.Empty : "/" + basePath.Trim('/');
            var normalizedKey = storageKey.Trim('/');
            return $"{normalizedBase}/{normalizedKey}";
        }
    }
}