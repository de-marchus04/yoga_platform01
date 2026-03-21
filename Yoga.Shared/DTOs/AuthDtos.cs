using System.ComponentModel.DataAnnotations;

namespace Yoga.Shared.DTOs
{
    public record LoginRequest(
        [Required, StringLength(100)] string Username,
        [Required, StringLength(128)] string Password
    );
    public record LoginResponse(string Token, string Username);
}
