namespace Yoga.Shared.Models
{
    public class UiTranslation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Key { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty; // "ru" | "uk" | "en"
        public string Value { get; set; } = string.Empty;
    }
}
