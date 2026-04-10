namespace Yoga.Shared.Models
{
    public class Yagya
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Slug { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime? EventStartDate { get; set; }
        public DateTime? EventEndDate { get; set; }

        public ICollection<YagyaSubcategory> Subcategories { get; set; } = new List<YagyaSubcategory>();
    }
}
