namespace Yoga.Api.Options
{
    public class ErrorTrackingOptions
    {
        public const string SectionName = "ErrorTracking";

        public bool Enabled { get; set; }
        public string Provider { get; set; } = "None";
        public string? Dsn { get; set; }
        public string? Environment { get; set; }
    }
}