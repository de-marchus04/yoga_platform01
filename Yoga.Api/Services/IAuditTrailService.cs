using System.Security.Claims;
using Yoga.Shared.Models;

namespace Yoga.Api.Services
{
    public interface IAuditTrailService
    {
        AdminAuditLog CreateEntry(
            ClaimsPrincipal user,
            HttpContext? httpContext,
            string action,
            string entityType,
            Guid? entityId,
            string summary,
            object? metadata = null);
    }
}