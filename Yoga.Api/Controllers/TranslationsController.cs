using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranslationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TranslationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("ui/{lang}")]
        [ResponseCache(Duration = 300)]
        public async Task<ActionResult<Dictionary<string, string>>> GetUiTranslations(string lang)
        {
            if (lang is not ("ru" or "uk" or "en"))
                return BadRequest("Supported languages: ru, uk, en");

            var dict = await _context.UiTranslations
                .Where(t => t.Language == lang)
                .ToDictionaryAsync(t => t.Key, t => t.Value);

            return Ok(dict);
        }
    }
}
