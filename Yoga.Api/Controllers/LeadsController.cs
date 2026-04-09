using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Yoga.Api.Data;
using Yoga.Api.Services;
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

        [HttpPost]
        [EnableRateLimiting("leads")]
        public async Task<IActionResult> CreateLead([FromBody] Lead lead)
        {
            if (!string.IsNullOrWhiteSpace(lead.ContactDetails) &&
                lead.Messager == "Phone" &&
                !IsValidPhone(lead.ContactDetails))
                return BadRequest(new { message = "Invalid phone number format." });

            lead.Id = Guid.NewGuid();
            lead.CreatedAt = DateTime.UtcNow;
            lead.IsProcessed = false;

            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();

            _ = _telegramService.SendLeadNotificationAsync(lead);

            return Ok(new { message = "Lead submitted successfully." });
        }

        private static bool IsValidPhone(string phone)
        {
            var digits = Regex.Replace(phone, @"[^\d]", "");
            return digits.Length >= 7 && digits.Length <= 15 && Regex.IsMatch(phone.Trim(), @"^\+\d");
        }
    }
}
