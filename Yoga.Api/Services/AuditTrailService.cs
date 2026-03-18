using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Yoga.Shared.Models;

namespace Yoga.Api.Services
{
    public class AuditTrailService : IAuditTrailService
    {
        public AdminAuditLog CreateEntry(
            ClaimsPrincipal user,
            HttpContext? httpContext,
            string action,
            string entityType,
            Guid? entityId,
            string summary,
            object? metadata = null)
        {
            var adminId = ResolveAdminId(user);
            var adminIdentifier = ResolveAdminIdentifier(user);
            var ipAddress = httpContext?.Connection.RemoteIpAddress?.ToString();

            return new AdminAuditLog
            {
                AdminUserId = adminId,
                AdminIdentifier = adminIdentifier,
                Action = action,
                EntityType = entityType,
                EntityId = entityId,
                Summary = summary,
                MetadataJson = metadata == null ? null : JsonSerializer.Serialize(metadata),
                IpAddress = ipAddress,
                CreatedAt = DateTime.UtcNow
            };
        }

        private static Guid? ResolveAdminId(ClaimsPrincipal user)
        {
            var sub = user.FindFirst(ClaimTypes.NameIdentifier)?.Value
                      ?? user.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            return Guid.TryParse(sub, out var id) ? id : null;
        }

        private static string? ResolveAdminIdentifier(ClaimsPrincipal user)
        {
            return user.Identity?.Name
                   ?? user.FindFirst(ClaimTypes.Name)?.Value
                   ?? user.FindFirst(JwtRegisteredClaimNames.UniqueName)?.Value
                   ?? user.FindFirst(ClaimTypes.Email)?.Value
                   ?? user.FindFirst(JwtRegisteredClaimNames.Email)?.Value
                   ?? user.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        }
    }
}