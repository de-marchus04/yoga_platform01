using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Api.Services;
using Yoga.Shared.DTOs;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITelegramService _telegramService;

        public LeadsController(AppDbContext context, ITelegramService telegramService)
        {
            _context = context;
            _telegramService = telegramService;
        }

        // POST: api/leads (Public - anyone can submit a lead)
        [HttpPost]
        [EnableRateLimiting("leads")]
        public async Task<IActionResult> CreateLead([FromBody] Lead lead)
        {
            lead.Id = Guid.NewGuid();
            lead.CreatedAt = DateTime.UtcNow;
            lead.IsProcessed = false;

            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();

            // Send async notification to Telegram
            _ = _telegramService.SendLeadNotificationAsync(lead);

            return Ok(new { message = "Lead submitted successfully." });
        }

        // GET: api/leads (Admin Only — paginated)
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<LeadSummaryDto>>> GetLeads(
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 20,
            [FromQuery] string? filter = null)
        {
            var query = _context.Leads.AsQueryable();

            if (filter == "unprocessed")
                query = query.Where(l => !l.IsProcessed);
            else if (filter == "processed")
                query = query.Where(l => l.IsProcessed);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(l => l.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(l => new LeadSummaryDto(
                    l.Id, l.Name, l.ContactDetails, l.Messager, l.Comment, l.CreatedAt, l.IsProcessed,
                    l.Status, l.TargetFormat, l.AdminNotes,
                    l.CourseId, l.ConsultationId, l.RetreatId,
                    _context.Courses.Where(c => c.Id == l.CourseId).Select(c => c.Slug).FirstOrDefault(),
                    _context.Consultations.Where(c => c.Id == l.ConsultationId).Select(c => c.Slug).FirstOrDefault(),
                    _context.Retreats.Where(r => r.Id == l.RetreatId).Select(r => r.Title).FirstOrDefault()
                ))
                .ToListAsync();

            return Ok(new PaginatedResult<LeadSummaryDto>(items, totalCount, page, pageSize));
        }

        // PUT: api/leads/{id}/process (Admin Only)
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}/process")]
        public async Task<IActionResult> MarkAsProcessed(Guid id, [FromQuery] bool processed = true)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null) return NotFound();

            lead.IsProcessed = processed;
            await _context.SaveChangesAsync();

            return Ok(lead);
        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] string status)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null) return NotFound();

            lead.Status = status;
            // Optionally update IsProcessed based on Status
            if (status == "Успешно" || status == "Отказ") lead.IsProcessed = true;
            else lead.IsProcessed = false;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("{id}/notes")]
        public async Task<IActionResult> UpdateNotes(Guid id, [FromBody] string notes)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null) return NotFound();

            lead.AdminNotes = notes;
            await _context.SaveChangesAsync();
            return Ok();
        }
        // DELETE: api/leads/{id} (Admin Only)
        [Authorize(Roles = "SuperAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLead(Guid id)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null) return NotFound();

            _context.Leads.Remove(lead);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/leads/{id}/create-customer — Create customer account from a lead
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("{id}/create-customer")]
        public async Task<IActionResult> CreateCustomerFromLead(Guid id, [FromBody] CreateCustomerFromLeadRequest req)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null) return NotFound();

            if (await _context.Customers.AnyAsync(c => c.Email == req.Email))
                return Conflict(new { message = "Email already exists" });

            var customer = new Customer
            {
                Email = req.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password),
                FullName = req.FullName,
                Phone = req.Phone,
                Messenger = req.Messenger
            };
            _context.Customers.Add(customer);

            lead.CustomerId = customer.Id;
            lead.Status = "Успешно";
            lead.IsProcessed = true;

            await _context.SaveChangesAsync();
            return Ok(new { customerId = customer.Id });
        }

        // POST: api/leads/{id}/grant-access — Grant access to the customer linked to this lead
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("{id}/grant-access")]
        public async Task<IActionResult> GrantAccessFromLead(Guid id, [FromBody] GrantAccessFromLeadRequest req)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null) return NotFound();

            var customer = await _context.Customers.FindAsync(req.CustomerId);
            if (customer == null) return NotFound(new { message = "Customer not found" });

            if (!Enum.TryParse<AccessType>(req.AccessType, true, out var accessType))
                return BadRequest(new { message = "Invalid access type" });

            var adminId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value
                          ?? User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)?.Value;

            var grant = new CustomerAccessGrant
            {
                CustomerId = req.CustomerId,
                AccessType = accessType,
                CourseId = req.CourseId,
                ConsultationId = req.ConsultationId,
                RetreatId = req.RetreatId,
                LiveEventId = req.LiveEventId,
                EndsAt = req.EndsAt,
                Notes = req.Notes,
                SourceLeadId = id,
                GrantedByAdminId = Guid.TryParse(adminId, out var aid) ? aid : null
            };
            _context.CustomerAccessGrants.Add(grant);

            // Link lead to customer if not already linked
            if (lead.CustomerId == null) lead.CustomerId = req.CustomerId;

            await _context.SaveChangesAsync();
            return Ok(new { grant.Id });
        }
    }
}
