using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Yoga.Api.Options;

namespace Yoga.Api.Services
{
    public class S3FileStorageService : IFileStorageService
    {
        private readonly StorageOptions _options;
        private readonly IAmazonS3 _client;

        public S3FileStorageService(IOptions<StorageOptions> options)
        {
            _options = options.Value;
            _client = CreateClient(_options);
        }

        public async Task<FileStorageResult> SaveAsync(IFormFile file, string? folder = null, CancellationToken cancellationToken = default)
        {
            EnsureConfigured();

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            var fileName = $"{Guid.NewGuid()}{extension}";
            var key = BuildObjectKey(folder, fileName);

            await using var stream = file.OpenReadStream();
            var request = new PutObjectRequest
            {
                BucketName = _options.BucketName,
                Key = key,
                InputStream = stream,
                ContentType = string.IsNullOrWhiteSpace(file.ContentType) ? "application/octet-stream" : file.ContentType
            };

            await _client.PutObjectAsync(request, cancellationToken);

            return new FileStorageResult(ResolvePublicUrl(key), key, file.Length, request.ContentType);
        }

        public async Task DeleteAsync(string url, CancellationToken cancellationToken = default)
        {
            EnsureConfigured();

            var key = ResolveObjectKey(url);
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }

            await _client.DeleteObjectAsync(new DeleteObjectRequest
            {
                BucketName = _options.BucketName,
                Key = key
            }, cancellationToken);
        }

        public async Task<bool> CheckHealthAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                EnsureConfigured();
                var response = await _client.ListObjectsV2Async(new ListObjectsV2Request
                {
                    BucketName = _options.BucketName,
                    MaxKeys = 1
                }, cancellationToken);

                return response.HttpStatusCode is System.Net.HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }

        public Task<FileAccessResult> GetReadAccessAsync(string url, bool isPrivate, TimeSpan? lifetime = null, CancellationToken cancellationToken = default)
        {
            EnsureConfigured();

            if (!isPrivate)
            {
                var publicUrl = Uri.TryCreate(url, UriKind.Absolute, out _) ? url : ResolvePublicUrl(ResolveObjectKey(url));
                return Task.FromResult(new FileAccessResult(publicUrl, null));
            }

            var key = ResolveObjectKey(url);
            if (string.IsNullOrWhiteSpace(key))
                throw new InvalidOperationException("Cannot generate signed URL without a valid object key.");

            var expiresAt = DateTimeOffset.UtcNow.Add(lifetime ?? TimeSpan.FromMinutes(_options.SignedUrlLifetimeMinutes));
            var signedUrl = _client.GetPreSignedURL(new GetPreSignedUrlRequest
            {
                BucketName = _options.BucketName,
                Key = key,
                Expires = expiresAt.UtcDateTime,
                Verb = HttpVerb.GET
            });

            return Task.FromResult(new FileAccessResult(signedUrl, expiresAt));
        }

        private void EnsureConfigured()
        {
            if (string.IsNullOrWhiteSpace(_options.BucketName))
                throw new InvalidOperationException("Storage:BucketName must be configured for S3 provider.");

            if (string.IsNullOrWhiteSpace(_options.ServiceUrl) && string.IsNullOrWhiteSpace(_options.Region))
                throw new InvalidOperationException("Storage:S3 requires either ServiceUrl or Region.");

            if (string.IsNullOrWhiteSpace(_options.AccessKey) || string.IsNullOrWhiteSpace(_options.SecretKey))
                throw new InvalidOperationException("Storage:S3 requires AccessKey and SecretKey.");
        }

        private string BuildObjectKey(string? folder, string fileName)
        {
            var segments = new List<string>();

            if (!string.IsNullOrWhiteSpace(_options.KeyPrefix))
                segments.Add(_options.KeyPrefix.Trim('/'));

            if (!string.IsNullOrWhiteSpace(folder))
                segments.Add(folder.Trim('/'));

            segments.Add(fileName);
            return string.Join('/', segments);
        }

        private string ResolvePublicUrl(string key)
        {
            if (!string.IsNullOrWhiteSpace(_options.PublicHost))
                return $"{_options.PublicHost.TrimEnd('/')}/{key}";

            if (!string.IsNullOrWhiteSpace(_options.ServiceUrl))
            {
                var baseUrl = _options.ServiceUrl.TrimEnd('/');
                if (_options.ForcePathStyle)
                    return $"{baseUrl}/{_options.BucketName}/{key}";

                var serviceUri = new Uri(baseUrl);
                return $"{serviceUri.Scheme}://{_options.BucketName}.{serviceUri.Host}{serviceUri.AbsolutePath.TrimEnd('/')}/{key}";
            }

            return $"https://{_options.BucketName}.s3.{_options.Region}.amazonaws.com/{key}";
        }

        private string ResolveObjectKey(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return string.Empty;

            if (Uri.TryCreate(url, UriKind.Absolute, out var absoluteUri))
            {
                var absolutePath = absoluteUri.AbsolutePath.Trim('/');
                if (_options.ForcePathStyle && absolutePath.StartsWith(_options.BucketName + "/", StringComparison.OrdinalIgnoreCase))
                    return absolutePath[(
                        _options.BucketName.Length + 1)..];

                return absolutePath;
            }

            return url.Trim('/');
        }

        private static IAmazonS3 CreateClient(StorageOptions options)
        {
            var config = new AmazonS3Config
            {
                ForcePathStyle = options.ForcePathStyle
            };

            if (!string.IsNullOrWhiteSpace(options.ServiceUrl))
                config.ServiceURL = options.ServiceUrl;

            if (!string.IsNullOrWhiteSpace(options.Region))
                config.RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(options.Region);

            var credentials = new BasicAWSCredentials(options.AccessKey, options.SecretKey);
            return new AmazonS3Client(credentials, config);
        }
    }
}