using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yoga.Api.Data;
using Yoga.Api.Services;
using Yoga.Shared.Models;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranslationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly GoogleTranslateService _translator;

        public TranslationsController(AppDbContext context, GoogleTranslateService translator)
        {
            _context = context;
            _translator = translator;
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

        // Image-related field names — copied as-is without translation
        private static readonly HashSet<string> ImageFields = new(StringComparer.OrdinalIgnoreCase)
        {
            "ImageUrl", "PresentationImage1Url", "PresentationImage2Url", "InstructorImageUrl"
        };

        /// <summary>
        /// POST /api/translations/auto-translate — translate single text field (admin).
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("auto-translate")]
        public async Task<ActionResult<TranslateResponse>> AutoTranslate([FromBody] TranslateRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Text))
                return Ok(new TranslateResponse(""));

            var translated = await _translator.TranslateAsync(request.Text, request.From, request.To);
            return Ok(new TranslateResponse(translated));
        }

        public record TranslateRequest(string Text, string From = "ru", string To = "en");
        public record TranslateResponse(string Text);

        /// <summary>
        /// POST /api/translations/auto-translate-entity — translate all fields of an entity from source to target language (admin).
        /// </summary>
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost("auto-translate-entity")]
        public async Task<IActionResult> AutoTranslateEntity([FromBody] AutoTranslateEntityRequest request)
        {
            var sourceTranslations = await _context.Translations
                .Where(t => t.EntityType == request.EntityType
                    && t.EntityId == request.EntityId
                    && t.Language == request.SourceLang)
                .ToListAsync();

            if (sourceTranslations.Count == 0) return Ok(new { translated = 0 });

            int count = 0;
            foreach (var src in sourceTranslations)
            {
                var existing = await _context.Translations
                    .FirstOrDefaultAsync(t => t.EntityType == src.EntityType
                        && t.EntityId == src.EntityId
                        && t.Field == src.Field
                        && t.Language == request.TargetLang);

                // Skip if already has content (don't overwrite manual edits)
                if (existing != null && !string.IsNullOrWhiteSpace(existing.Value)) continue;

                string value;
                if (ImageFields.Contains(src.Field))
                    value = src.Value; // Copy images as-is
                else
                    value = await _translator.TranslateAsync(src.Value, request.SourceLang, request.TargetLang);

                if (existing != null)
                {
                    existing.Value = value;
                }
                else
                {
                    _context.Translations.Add(new Translation
                    {
                        EntityType = src.EntityType,
                        EntityId = src.EntityId,
                        Field = src.Field,
                        Language = request.TargetLang,
                        Value = value
                    });
                }
                count++;
            }

            await _context.SaveChangesAsync();
            return Ok(new { translated = count });
        }

        public record AutoTranslateEntityRequest(string EntityType, Guid EntityId, string SourceLang = "ru", string TargetLang = "en");
    }
}
