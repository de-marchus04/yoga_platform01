namespace Yoga.Shared.DTOs;

public record AdminLoginRequest(string Login, string Password);

public record AdminLoginResponse(string Token, DateTime ExpiresAt);
