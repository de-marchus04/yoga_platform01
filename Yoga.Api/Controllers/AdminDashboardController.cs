using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Shared.DTOs;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/admin/dashboard")]
    [Authorize(Roles = "SuperAdmin")]
    public class AdminDashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminDashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<DashboardDto>> GetDashboard()
        {
            var totalRetreats = await _context.Retreats.CountAsync();
            var activeRetreats = await _context.Retreats.CountAsync(r => r.IsActive);
            var totalCourses = await _context.Courses.CountAsync();
            var totalConsultations = await _context.Consultations.CountAsync();
            var totalBlogPosts = await _context.BlogPosts.CountAsync();
            var totalLeads = await _context.Leads.CountAsync();
            var unprocessedLeads = await _context.Leads.CountAsync(l => !l.IsProcessed);

            var recentLeads = await _context.Leads
                .OrderByDescending(l => l.CreatedAt)
                .Take(10)
                .Select(l => new LeadSummaryDto(
                    l.Id, l.Name, l.ContactDetails, l.Messager, l.Comment, l.CreatedAt, l.IsProcessed,
                    l.Status, l.TargetFormat, l.AdminNotes,
                    l.CourseId, l.ConsultationId, l.RetreatId,
                    _context.Courses.Where(c => c.Id == l.CourseId).Select(c => c.Slug).FirstOrDefault(),
                    _context.Consultations.Where(c => c.Id == l.ConsultationId).Select(c => c.Slug).FirstOrDefault(),
                    _context.Retreats.Where(r => r.Id == l.RetreatId).Select(r => r.Title).FirstOrDefault()
                ))
                .ToListAsync();

            // Activity: leads per day for last 30 days
            var since = DateTime.UtcNow.AddDays(-30).Date;
            var recentLeadDates = await _context.Leads
                .Where(l => l.CreatedAt >= since)
                .Select(l => l.CreatedAt)
                .ToListAsync();
            var activity = recentLeadDates
                .GroupBy(d => d.Date)
                .Select(g => new ActivityDayDto(g.Key, g.Count()))
                .OrderBy(a => a.Date)
                .ToList();

            return Ok(new DashboardDto(
                totalRetreats, activeRetreats, totalCourses, totalConsultations,
                totalBlogPosts, totalLeads, unprocessedLeads, recentLeads, activity
            ));
        }
    }
}
