using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yoga.Api.Services;
using Yoga.Shared.DTOs;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/admin/content")]
    [Authorize(Roles = "SuperAdmin")]
    public class AdminContentController : ControllerBase
    {
        private readonly PublicContentResetService _publicContentResetService;

        public AdminContentController(PublicContentResetService publicContentResetService)
        {
            _publicContentResetService = publicContentResetService;
        }

        [HttpGet("public-reset-preview")]
        public async Task<ActionResult<PublicContentResetPreviewDto>> GetPublicResetPreview(CancellationToken cancellationToken)
        {
            var preview = await _publicContentResetService.PreviewAsync(cancellationToken);
            return Ok(preview);
        }

        [HttpPost("reset-public")]
        public async Task<ActionResult<PublicContentResetResultDto>> ResetPublicContent(CancellationToken cancellationToken)
        {
            var result = await _publicContentResetService.ResetAsync(User, HttpContext, cancellationToken);
            return Ok(result);
        }
    }
}