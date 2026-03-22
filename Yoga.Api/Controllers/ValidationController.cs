using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Yoga.Api.Controllers
{
    [ApiController]
    [Route("api/validate-email")]
    public class ValidationController : ControllerBase
    {
        /// <summary>
        /// Checks if the given email domain resolves in DNS (has at least one A/AAAA record).
        /// Used by client-side email input to verify the domain is real.
        /// </summary>
        [HttpGet]
        [EnableRateLimiting("validation")]
        public async Task<IActionResult> ValidateEmailDomain([FromQuery] string? domain)
        {
            if (string.IsNullOrWhiteSpace(domain) || domain.Length > 253)
                return Ok(new { valid = false, reason = "invalid_format" });

            domain = domain.Trim().ToLowerInvariant();

            // Basic sanity checks before the DNS call
            if (domain.Contains(' ') || !domain.Contains('.') ||
                domain.StartsWith('.') || domain.EndsWith('.') ||
                domain.Contains(".."))
                return Ok(new { valid = false, reason = "invalid_domain" });

            try
            {
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                var addresses = await Dns.GetHostAddressesAsync(domain, cts.Token);
                return Ok(new { valid = addresses.Length > 0, reason = "ok" });
            }
            catch (OperationCanceledException)
            {
                // DNS timeout — be lenient so valid users on slow connections aren't blocked
                return Ok(new { valid = true, reason = "timeout" });
            }
            catch (SocketException ex)
                when (ex.SocketErrorCode is SocketError.HostNotFound
                                         or SocketError.NoData
                                         or SocketError.TryAgain)
            {
                return Ok(new { valid = false, reason = "domain_not_found" });
            }
            catch
            {
                // Any other error — be lenient
                return Ok(new { valid = true, reason = "error" });
            }
        }
    }
}
