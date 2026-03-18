namespace Yoga.Api.Options
{
    public class SecurityOptions
    {
        public const string SectionName = "Security";

        public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
        public bool EnableHsts { get; set; } = true;
    }
}