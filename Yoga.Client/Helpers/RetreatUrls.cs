using Yoga.Shared.DTOs;

namespace Yoga.Client.Helpers
{
    public static class RetreatUrls
    {
        public static string DetailPath(RetreatDto r) =>
            !string.IsNullOrWhiteSpace(r.Slug) ? $"/retreats/{r.Slug}" : $"/retreats/{r.Id}";
    }
}
