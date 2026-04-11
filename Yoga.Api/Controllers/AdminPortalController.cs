using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Yoga.Api.Data;
using Yoga.Api.Options;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminPortalController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IConfiguration _config;
    private readonly AdminPortalOptions _options;

    public AdminPortalController(AppDbContext db, IConfiguration config, IOptions<AdminPortalOptions> options)
    {
        _db = db;
        _config = config;
        _options = options.Value;
    }

    [HttpPost("login")]
    [EnableRateLimiting("validation")]
    public async Task<ActionResult<AdminLoginResponse>> Login([FromBody] AdminLoginRequest? body)
    {
        if (body is null || string.IsNullOrWhiteSpace(body.Login) || string.IsNullOrWhiteSpace(body.Password))
            return BadRequest();

        var user = await _db.AdminUsers.FirstOrDefaultAsync(u => u.Login == body.Login);
        if (user is null)
            return Unauthorized();

        if (!VerifyPassword(body.Password, user.PasswordHash))
            return Unauthorized();

        var token = GenerateJwt(user);
        var expiresAt = DateTime.UtcNow.AddHours(8);
        return Ok(new AdminLoginResponse(token, expiresAt));
    }

    [HttpPost("seed-admin")]
    [EnableRateLimiting("validation")]
    public async Task<IActionResult> SeedAdmin([FromHeader(Name = "X-Admin-Bootstrap-Token")] string? bootstrapToken)
    {
        if (!_options.EnableSeedAdminEndpoint)
            return NotFound();

        if (string.IsNullOrWhiteSpace(_options.SeedAdminBootstrapToken))
            return Problem(
                title: "Seed admin endpoint misconfigured",
                detail: "AdminPortal:SeedAdminBootstrapToken must be configured when AdminPortal:EnableSeedAdminEndpoint is enabled.",
                statusCode: StatusCodes.Status500InternalServerError);

        if (!SecretsEqual(bootstrapToken, _options.SeedAdminBootstrapToken))
            return Forbid();

        if (await _db.AdminUsers.AnyAsync())
            return Conflict("Admin user already exists.");

        var login = _options.Login;
        var password = _options.Password;

        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            return BadRequest("AdminPortal:Login and AdminPortal:Password must be configured.");

        var user = new AdminUser
        {
            Login = login,
            PasswordHash = HashPassword(password)
        };

        _db.AdminUsers.Add(user);
        await _db.SaveChangesAsync();
        return Ok("Admin user created.");
    }

    [HttpGet("me")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<AdminCurrentUserDto>> Me()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userId, out var parsedId))
            return Unauthorized();

        var user = await _db.AdminUsers.FirstOrDefaultAsync(x => x.Id == parsedId);
        if (user is null)
            return Unauthorized();

        return Ok(new AdminCurrentUserDto(user.Id, user.Login));
    }

    private static bool SecretsEqual(string? provided, string expected)
    {
        if (string.IsNullOrWhiteSpace(provided) || string.IsNullOrWhiteSpace(expected))
            return false;

        var providedBytes = Encoding.UTF8.GetBytes(provided.Trim());
        var expectedBytes = Encoding.UTF8.GetBytes(expected.Trim());
        return CryptographicOperations.FixedTimeEquals(providedBytes, expectedBytes);
    }

    private string GenerateJwt(AdminUser user)
    {
        var secret = _config["AdminPortal:JwtSecret"] ?? throw new InvalidOperationException("AdminPortal:JwtSecret not configured.");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Role, "Admin")
        };

        var token = new JwtSecurityToken(
            issuer: "yoga-api",
            audience: "yoga-client",
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(16);
        var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, 100_000, HashAlgorithmName.SHA256, 32);
        return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
    }

    private static bool VerifyPassword(string password, string storedHash)
    {
        var parts = storedHash.Split(':');
        if (parts.Length != 2) return false;

        var salt = Convert.FromBase64String(parts[0]);
        var expectedHash = Convert.FromBase64String(parts[1]);
        var actualHash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, 100_000, HashAlgorithmName.SHA256, 32);
        return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
    }
}
