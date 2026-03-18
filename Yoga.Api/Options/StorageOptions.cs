namespace Yoga.Api.Options
{
    public class StorageOptions
    {
        public const string SectionName = "Storage";

        public string Provider { get; set; } = "Local";
        public string LocalRootPath { get; set; } = "wwwroot/uploads";
        public string PublicBaseUrl { get; set; } = "/uploads";
        public string PublicHost { get; set; } = string.Empty;
        public string BucketName { get; set; } = string.Empty;
        public string ServiceUrl { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string AccessKey { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public bool ForcePathStyle { get; set; } = true;
        public string KeyPrefix { get; set; } = string.Empty;
        public int SignedUrlLifetimeMinutes { get; set; } = 20;
    }
}