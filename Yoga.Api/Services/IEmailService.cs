namespace Yoga.Api.Services
{
    public interface IEmailService
    {
        Task SendPasswordResetAsync(string toEmail, string toName, string resetUrl);
        Task SendWelcomeAsync(string toEmail, string toName);
        Task SendAccessGrantedAsync(string toEmail, string toName, string productName);
    }
}
