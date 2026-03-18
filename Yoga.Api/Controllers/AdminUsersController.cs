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
    [Route("api/admin/users")]
    [Authorize(Roles = "SuperAdmin")]
    public class AdminUsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAuditTrailService _auditTrailService;

        public AdminUsersController(AppDbContext context, IAuditTrailService auditTrailService)
        {
            _context = context;
            _auditTrailService = auditTrailService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdminUserDto>>> GetAll()
        {
            var users = await _context.AdminUsers
                .OrderBy(u => u.Username)
                .Select(u => new AdminUserDto(u.Id, u.Username, u.DisplayName, u.Email, u.CreatedAt, u.LastLoginAt))
                .ToListAsync();

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<AdminUserDto>> Create([FromBody] CreateAdminUserRequest request)
        {
            if (await _context.AdminUsers.AnyAsync(u => u.Username == request.Username))
                return Conflict(new { message = "Username already exists" });

            var user = new AdminUser
            {
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                DisplayName = request.DisplayName,
                Email = request.Email,
                CreatedAt = DateTime.UtcNow
            };

            _context.AdminUsers.Add(user);
            _context.AdminAuditLogs.Add(_auditTrailService.CreateEntry(
                User,
                HttpContext,
                "admin-user-created",
                nameof(AdminUser),
                user.Id,
                $"Admin user '{user.Username}' created.",
                new { user.Username, user.DisplayName, user.Email }));
            await _context.SaveChangesAsync();

            return Created($"api/admin/users/{user.Id}",
                new AdminUserDto(user.Id, user.Username, user.DisplayName, user.Email, user.CreatedAt, user.LastLoginAt));
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var adminIdValue = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value
                ?? User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)?.Value;

            if (!Guid.TryParse(adminIdValue, out var adminId))
                return Unauthorized(new { message = "Admin identity is invalid" });

            var user = await _context.AdminUsers.FirstOrDefaultAsync(u => u.Id == adminId);
            if (user == null)
                return Unauthorized(new { message = "Admin user not found" });

            if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.PasswordHash))
                return BadRequest(new { message = "Current password is incorrect" });

            if (string.IsNullOrWhiteSpace(request.NewPassword) || request.NewPassword.Length < 12)
                return BadRequest(new { message = "New password must contain at least 12 characters" });

            if (request.NewPassword == request.CurrentPassword)
                return BadRequest(new { message = "New password must differ from the current password" });

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            _context.AdminAuditLogs.Add(_auditTrailService.CreateEntry(
                User,
                HttpContext,
                "admin-password-changed",
                nameof(AdminUser),
                user.Id,
                $"Password changed for admin '{user.Username}'.",
                new { user.Username }));

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            // Prevent deleting the last admin
            var count = await _context.AdminUsers.CountAsync();
            if (count <= 1)
                return BadRequest(new { message = "Cannot delete the last admin user" });

            var user = await _context.AdminUsers.FindAsync(id);
            if (user == null) return NotFound();

            _context.AdminUsers.Remove(user);
            _context.AdminAuditLogs.Add(_auditTrailService.CreateEntry(
                User,
                HttpContext,
                "admin-user-deleted",
                nameof(AdminUser),
                user.Id,
                $"Admin user '{user.Username}' deleted.",
                new { user.Username, user.DisplayName, user.Email }));
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
