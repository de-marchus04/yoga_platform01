namespace Yoga.Shared.Models
{
    public class Translation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string EntityType { get; set; } = string.Empty;
        public Guid EntityId { get; set; }
        public string Field { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty; // "ru" | "uk" | "en"
        public string Value { get; set; } = string.Empty;
    }
}
