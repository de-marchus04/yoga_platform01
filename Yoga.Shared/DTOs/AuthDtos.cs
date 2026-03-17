namespace Yoga.Shared.DTOs
{
    public record LoginRequest(string Username, string Password);
    public record LoginResponse(string Token, string Username);
}
