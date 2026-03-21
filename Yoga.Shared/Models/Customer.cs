using System;
using System.ComponentModel.DataAnnotations;

namespace Yoga.Shared.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, EmailAddress, StringLength(200)]
        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Messenger { get; set; } // Telegram, WhatsApp, etc.

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }

        public int FailedLoginAttempts { get; set; } = 0;
        public DateTime? LockoutEndUtc { get; set; }

        /// <summary>Active library subscription (null = no subscription).</summary>
        public CustomerSubscription? Subscription { get; set; }
        public ICollection<CustomerAccessGrant> AccessGrants { get; set; } = new List<CustomerAccessGrant>();
    }
}
