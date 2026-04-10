namespace Yoga.Shared.Models
{
    public class YagyaSubcategory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid YagyaId { get; set; }
        public Yagya? Yagya { get; set; }
        public string Slug { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }
}
