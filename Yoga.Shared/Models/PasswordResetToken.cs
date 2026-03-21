namespace Yoga.Shared.Models
{
    public class PasswordResetToken
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Customer Customer { get; set; } = null!;
    }
}
