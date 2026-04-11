namespace Yoga.Shared.Models
{
    public class Course
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Slug { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool IsDraft { get; set; } = false;

        public bool IsOnline { get; set; } = false;
        public bool IsOffline { get; set; } = false;

        public ICollection<CourseModule> Modules { get; set; } = new List<CourseModule>();
    }
}
