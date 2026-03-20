namespace Yoga.Shared.Models
{
    public class CourseLesson
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CourseModuleId { get; set; }
        public CourseModule? Module { get; set; }
        public int SortOrder { get; set; } = 0;
    }
}
