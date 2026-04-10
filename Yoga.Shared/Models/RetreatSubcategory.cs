namespace Yoga.Shared.Models
{
    public class RetreatSubcategory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid RetreatId { get; set; }
        public Retreat? Retreat { get; set; }
        public string Slug { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }
}
