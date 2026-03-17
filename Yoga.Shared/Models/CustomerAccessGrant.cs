using System;

namespace Yoga.Shared.Models
{
    /// <summary>Point access grant: course, consultation, retreat or live event for a customer.</summary>
    public class CustomerAccessGrant
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public AccessType AccessType { get; set; }

        // Exactly one of these should be set depending on AccessType
        public Guid? CourseId { get; set; }
        public Guid? ConsultationId { get; set; }
        public Guid? RetreatId { get; set; }
        public Guid? LiveEventId { get; set; }

        public DateTime StartsAt { get; set; } = DateTime.UtcNow;
        public DateTime? EndsAt { get; set; }

        public string Status { get; set; } = "Active"; // Active | Expired | Revoked

        public Guid? GrantedByAdminId { get; set; }
        public Guid? SourceLeadId { get; set; }

        [System.ComponentModel.DataAnnotations.StringLength(1000)]
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum AccessType
    {
        Course = 1,
        Consultation = 2,
        Retreat = 3,
        LiveEvent = 4,
        LiveEventSeries = 5
    }
}
