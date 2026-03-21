using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Api.Services;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/admin/access")]
    [Authorize(Roles = "SuperAdmin")]
    public class CustomerAccessController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAuditTrailService _auditTrail;

        public CustomerAccessController(AppDbContext context, IAuditTrailService auditTrail)
        {
            _context = context;
            _auditTrail = auditTrail;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<AccessGrantDto>>> GetAll(
            [FromQuery] Guid? customerId = null, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            page = Math.Max(1, page);
            pageSize = Math.Clamp(pageSize, 1, 100);
            var query = _context.CustomerAccessGrants.Include(g => g.Customer).AsQueryable();
            if (customerId.HasValue) query = query.Where(g => g.CustomerId == customerId);

            var total = await query.CountAsync();
            var items = await query.OrderByDescending(g => g.CreatedAt)
                .Skip((page - 1) * pageSize).Take(pageSize)
                .Select(g => new AccessGrantDto(
                    g.Id, g.CustomerId, g.Customer.FullName, g.AccessType.ToString(),
                    g.CourseId, g.ConsultationId, g.RetreatId, g.LiveEventId,
                    g.StartsAt, g.EndsAt, g.Status, g.SourceLeadId, g.Notes, g.CreatedAt,
                    null, null, null, null, null, null, g.YagyaId, null
                )).ToListAsync();

            return Ok(new PaginatedResult<AccessGrantDto>(items, total, page, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAccessGrantRequest req)
        {
            if (!Enum.TryParse<AccessType>(req.AccessType, true, out var accessType))
                return BadRequest(new { message = "Invalid access type" });

            var customer = await _context.Customers.FindAsync(req.CustomerId);
            if (customer == null) return NotFound(new { message = "Customer not found" });

            var grant = new CustomerAccessGrant
            {
                CustomerId = req.CustomerId,
                AccessType = accessType,
                CourseId = req.CourseId,
                ConsultationId = req.ConsultationId,
                RetreatId = req.RetreatId,
                LiveEventId = req.LiveEventId,
                YagyaId = req.YagyaId,
                StartsAt = req.StartsAt ?? DateTime.UtcNow,
                EndsAt = req.EndsAt,
                SourceLeadId = req.SourceLeadId,
                Notes = req.Notes,
                GrantedByAdminId = GetAdminId()
            };

            _context.CustomerAccessGrants.Add(grant);
            _context.AdminAuditLogs.Add(_auditTrail.CreateEntry(
                User,
                HttpContext,
                "access-grant-created",
                nameof(CustomerAccessGrant),
                grant.Id,
                $"Granted {grant.AccessType} access to customer {customer.FullName}.",
                new
                {
                    grant.CustomerId,
                    grant.AccessType,
                    grant.CourseId,
                    grant.ConsultationId,
                    grant.RetreatId,
                    grant.LiveEventId,
                    grant.YagyaId,
                    grant.SourceLeadId,
                    grant.StartsAt,
                    grant.EndsAt
                }));
            await _context.SaveChangesAsync();

            return Ok(new { grant.Id });
        }

        [HttpPut("{id:guid}/revoke")]
        public async Task<IActionResult> Revoke(Guid id)
        {
            var grant = await _context.CustomerAccessGrants.FindAsync(id);
            if (grant == null) return NotFound();
            grant.Status = "Revoked";
            _context.AdminAuditLogs.Add(_auditTrail.CreateEntry(
                User,
                HttpContext,
                "access-grant-revoked",
                nameof(CustomerAccessGrant),
                grant.Id,
                $"Revoked {grant.AccessType} access for customer {grant.CustomerId}.",
                new
                {
                    grant.CustomerId,
                    grant.AccessType,
                    grant.CourseId,
                    grant.ConsultationId,
                    grant.RetreatId,
                    grant.LiveEventId,
                    grant.YagyaId
                }));
            await _context.SaveChangesAsync();
            return Ok();
        }

        private Guid? GetAdminId()
        {
            var sub = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value
                      ?? User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)?.Value;
            return Guid.TryParse(sub, out var id) ? id : null;
        }
    }
}
