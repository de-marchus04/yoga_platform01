using System;

namespace Yoga.Shared.Models
{
    /// <summary>Library-level subscription for a customer (premium access to the whole library).</summary>
    public class CustomerSubscription
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public SubscriptionTier Tier { get; set; } = SubscriptionTier.Premium;

        public DateTime StartsAt { get; set; } = DateTime.UtcNow;
        public DateTime? EndsAt { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid? GrantedByAdminId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum SubscriptionTier
    {
        Premium = 1,
        Vip = 2
    }
}
