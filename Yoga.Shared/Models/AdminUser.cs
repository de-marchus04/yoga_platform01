namespace Yoga.Shared.Models
{
    public class AdminUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
