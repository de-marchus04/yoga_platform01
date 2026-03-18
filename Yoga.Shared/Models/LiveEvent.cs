using System;
using System.ComponentModel.DataAnnotations;

namespace Yoga.Shared.Models
{
    public class LiveEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(300)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime StartsAt { get; set; }
        public DateTime? EndsAt { get; set; }

        /// <summary>"Scheduled" | "Live" | "Ended" | "Cancelled"</summary>
        [StringLength(30)]
        public string Status { get; set; } = "Scheduled";

        /// <summary>Zoom/external join URL (shown only to authorized customers).</summary>
        public string? JoinUrl { get; set; }

        /// <summary>Recording URL (available after the event ends).</summary>
        public string? RecordingUrl { get; set; }

        public bool IsRecordingPrivate { get; set; } = true;

        /// <summary>Access policy: "GrantOnly" (per-customer grant) | "AllSubscribers" | "Public"</summary>
        [StringLength(30)]
        public string AccessPolicy { get; set; } = "GrantOnly";

        /// <summary>Optional series identifier to group events.</summary>
        public Guid? SeriesId { get; set; }

        public bool IsPublished { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
