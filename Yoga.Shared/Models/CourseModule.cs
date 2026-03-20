namespace Yoga.Shared.Models
{
    public class CourseModule
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CourseId { get; set; }
        public Course? Course { get; set; }
        public int SortOrder { get; set; } = 0;
        public ICollection<CourseLesson> Lessons { get; set; } = new List<CourseLesson>();
    }
}
