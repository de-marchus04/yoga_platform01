using System;
using System.ComponentModel.DataAnnotations;

namespace Yoga.Shared.Models
{
    public class AdminAuditLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? AdminUserId { get; set; }

        [StringLength(200)]
        public string? AdminIdentifier { get; set; }

        [Required, StringLength(120)]
        public string Action { get; set; } = string.Empty;

        [Required, StringLength(120)]
        public string EntityType { get; set; } = string.Empty;

        public Guid? EntityId { get; set; }

        [StringLength(300)]
        public string Summary { get; set; } = string.Empty;

        public string? MetadataJson { get; set; }

        [StringLength(100)]
        public string? IpAddress { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}