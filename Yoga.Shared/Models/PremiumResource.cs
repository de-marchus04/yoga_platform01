using System;
using System.ComponentModel.DataAnnotations;

namespace Yoga.Shared.Models
{
    public class PremiumResource
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        /// <summary>"video" | "guide" | "masterclass" | "audio" | "document"</summary>
        [Required, StringLength(50)]
        public string ResourceType { get; set; } = "video";

        public string? MediaUrl { get; set; }
        public bool IsPrivateMedia { get; set; } = true;
        public TimeSpan? Duration { get; set; }
        public int SortOrder { get; set; }
        public bool IsActive { get; set; } = true;

        /// <summary>Minimum subscription tier required, or null if accessible via point grant only.</summary>
        public SubscriptionTier? MinimumTier { get; set; }

        /// <summary>Optional category for organizing the library.</summary>
        [StringLength(100)]
        public string? Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
