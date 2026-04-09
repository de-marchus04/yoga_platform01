using System.Text.RegularExpressions;

namespace Yoga.Api.Services
{
    /// <summary>Public retreat URLs: venue code + number, e.g. me01, ua02 (lowercase).</summary>
    public static class RetreatSlugRules
    {
        private static readonly Regex Pattern = new(@"^[a-z]{2}\d+$", RegexOptions.Compiled);

        public static bool IsValidFormat(string? slug) =>
            !string.IsNullOrWhiteSpace(slug) && Pattern.IsMatch(slug.Trim());

        public static string? FormatError =>
            "Slug must match venue + index, e.g. me01 (Montenegro, first), ua02 — lowercase letters then digits.";
    }
}
