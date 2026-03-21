using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Shared.DTOs;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/admin/audit")]
    [Authorize(Roles = "SuperAdmin")]
    public class AdminAuditController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminAuditController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<AdminAuditLogDto>>> GetAll(
            [FromQuery] string? action = null,
            [FromQuery] string? entityType = null,
            [FromQuery] Guid? entityId = null,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 50)
        {
            page = Math.Max(1, page);
            pageSize = Math.Clamp(pageSize, 1, 100);
            var query = _context.AdminAuditLogs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(action))
                query = query.Where(x => x.Action == action);

            if (!string.IsNullOrWhiteSpace(entityType))
                query = query.Where(x => x.EntityType == entityType);

            if (entityId.HasValue)
                query = query.Where(x => x.EntityId == entityId);

            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(x => x.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new AdminAuditLogDto(
                    x.Id,
                    x.AdminUserId,
                    x.AdminIdentifier,
                    x.Action,
                    x.EntityType,
                    x.EntityId,
                    x.Summary,
                    x.MetadataJson,
                    x.IpAddress,
                    x.CreatedAt))
                .ToListAsync();

            return Ok(new PaginatedResult<AdminAuditLogDto>(items, totalCount, page, pageSize));
        }
    }
}