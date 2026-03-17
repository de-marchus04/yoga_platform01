namespace Yoga.Shared.Models
{
    public class MediaFile
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string EntityType { get; set; } = string.Empty;
        public Guid EntityId { get; set; }
        public string Url { get; set; } = string.Empty;
        public string? Alt { get; set; }
        public int SortOrder { get; set; } = 0;
    }
}
