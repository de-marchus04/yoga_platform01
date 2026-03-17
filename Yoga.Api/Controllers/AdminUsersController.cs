using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
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

        public AdminUsersController(AppDbContext context)
        {
            _context = context;
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
            await _context.SaveChangesAsync();

            return Created($"api/admin/users/{user.Id}",
                new AdminUserDto(user.Id, user.Username, user.DisplayName, user.Email, user.CreatedAt, user.LastLoginAt));
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
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
