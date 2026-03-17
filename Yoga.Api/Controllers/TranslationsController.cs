using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Shared.Models;

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

        /// <summary>
        /// GET /api/translations/ui/{lang} — all UI translations for a language (public, cacheable).
        /// </summary>
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

        /// <summary>
        /// GET /api/translations/{entityType}/{entityId}/{lang} — translations for a specific entity.
        /// </summary>
        [HttpGet("{entityType}/{entityId:guid}/{lang}")]
        public async Task<ActionResult<Dictionary<string, string>>> GetEntityTranslations(
            string entityType, Guid entityId, string lang)
        {
            if (lang is not ("ru" or "uk" or "en"))
                return BadRequest("Supported languages: ru, uk, en");

            var dict = await _context.Translations
                .Where(t => t.EntityType == entityType && t.EntityId == entityId && t.Language == lang)
                .ToDictionaryAsync(t => t.Field, t => t.Value);

            return Ok(dict);
        }

        /// <summary>
        /// PUT /api/translations/ui — upsert a single UI translation (admin).
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("ui")]
        public async Task<IActionResult> UpsertUiTranslation([FromBody] UiTranslation dto)
        {
            var existing = await _context.UiTranslations
                .FirstOrDefaultAsync(t => t.Key == dto.Key && t.Language == dto.Language);

            if (existing != null)
            {
                existing.Value = dto.Value;
            }
            else
            {
                dto.Id = Guid.NewGuid();
                _context.UiTranslations.Add(dto);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// PUT /api/translations/entity — upsert a single entity translation (admin).
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPut("entity")]
        public async Task<IActionResult> UpsertEntityTranslation([FromBody] Translation dto)
        {
            var existing = await _context.Translations
                .FirstOrDefaultAsync(t => t.EntityType == dto.EntityType
                    && t.EntityId == dto.EntityId
                    && t.Field == dto.Field
                    && t.Language == dto.Language);

            if (string.IsNullOrWhiteSpace(dto.Value))
            {
                // Если пришло пустое значение — удаляем перевод, чтобы сработал фоллбек (например, на главной)
                if (existing != null)
                {
                    _context.Translations.Remove(existing);
                    await _context.SaveChangesAsync();
                }
                return Ok();
            }

            if (existing != null)
            {
                existing.Value = dto.Value.Trim();
            }
            else
            {
                dto.Id = Guid.NewGuid();
                dto.Value = dto.Value.Trim();
                _context.Translations.Add(dto);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// GET /api/translations/{entityType}/{entityId}/all — all translations for an entity (admin).
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("{entityType}/{entityId:guid}/all")]
        public async Task<ActionResult<List<Translation>>> GetAllEntityTranslations(string entityType, Guid entityId)
        {
            var list = await _context.Translations
                .Where(t => t.EntityType == entityType && t.EntityId == entityId)
                .OrderBy(t => t.Language).ThenBy(t => t.Field)
                .ToListAsync();
            return Ok(list);
        }
    }
}
