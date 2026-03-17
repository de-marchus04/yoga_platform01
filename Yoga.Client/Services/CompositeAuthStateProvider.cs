using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace Yoga.Client.Services
{
    /// <summary>
    /// Composite AuthenticationStateProvider that checks both admin and user tokens.
    /// Admin token: "yl-admin-token" → roles include "SuperAdmin"
    /// User token: "yl-user-token" → roles include "Customer"
    /// </summary>
    public class CompositeAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _js;
        private const string AdminTokenKey = "yl-admin-token";
        private const string UserTokenKey = "yl-user-token";

        public CompositeAuthStateProvider(IJSRuntime js) => _js = js;

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                // Try admin token first
                var adminToken = await _js.InvokeAsync<string?>("localStorage.getItem", AdminTokenKey);
                var adminState = TryParseToken(adminToken);
                if (adminState != null) return adminState;

                // Then user token
                var userToken = await _js.InvokeAsync<string?>("localStorage.getItem", UserTokenKey);
                var userState = TryParseToken(userToken);
                if (userState != null) return userState;
            }
            catch { }

            return Anonymous();
        }

        // Called by AdminAuthService
        public void NotifyAdminAuthentication(string token)
        {
            var claims = ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "jwt");
            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        // Called by UserAuthService
        public void NotifyUserAuthentication(string token)
        {
            var claims = ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "jwt");
            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public void NotifyLogout()
        {
            NotifyAuthenticationStateChanged(Task.FromResult(Anonymous()));
        }

        private AuthenticationState? TryParseToken(string? token)
        {
            if (string.IsNullOrEmpty(token)) return null;
            var claims = ParseClaimsFromJwt(token);
            if (claims == null) return null;

            var expClaim = claims.FirstOrDefault(c => c.Type == "exp");
            if (expClaim != null && long.TryParse(expClaim.Value, out var exp))
            {
                if (DateTimeOffset.FromUnixTimeSeconds(exp) <= DateTimeOffset.UtcNow)
                    return null;
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt")));
        }

        private static IEnumerable<Claim>? ParseClaimsFromJwt(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                return jwt.Claims;
            }
            catch { return null; }
        }

        private static AuthenticationState Anonymous() =>
            new(new ClaimsPrincipal(new ClaimsIdentity()));
    }
}
