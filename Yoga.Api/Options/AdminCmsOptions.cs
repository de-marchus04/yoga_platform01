namespace Yoga.Api.Options;

public class AdminCmsOptions
{
    public const string SectionName = "AdminCms";

    /// <summary>Allows authenticated admins to seed temporary sample content.</summary>
    public bool EnableSampleContentBootstrap { get; set; }
}