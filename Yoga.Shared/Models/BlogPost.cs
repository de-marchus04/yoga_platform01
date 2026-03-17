namespace Yoga.Shared.Models
{
    public class BlogPost
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Slug { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; // "articles" | "videos" | "photos"
        public string? MediaUrl { get; set; }
        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        // Site sections this post belongs to: "courses"|"consultations"|"retreats"
        public string[] Sections { get; set; } = [];
        
        // Exact targeting IDs
        public Guid? RelatedCourseId { get; set; }
        public Guid? RelatedConsultationId { get; set; }
        public Guid? RelatedRetreatId { get; set; }
    }
}
