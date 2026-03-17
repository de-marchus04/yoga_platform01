namespace Yoga.Shared.Models
{
    public class SitePage
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Slug { get; set; } = string.Empty; // "about" | "contacts"
    }
}
