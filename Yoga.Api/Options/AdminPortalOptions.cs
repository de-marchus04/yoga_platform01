namespace Yoga.Api.Options;

public class AdminPortalOptions
{
    public const string SectionName = "AdminPortal";

    /// <summary>Absolute URL of the external admin UI (opened after successful verify).</summary>
    public string PortalUrl { get; set; } = "";

    /// <summary>If set, login must match exactly (case-sensitive).</summary>
    public string Login { get; set; } = "";

    /// <summary>Shared secret checked on the server; never exposed to the client.</summary>
    public string Password { get; set; } = "";
}
