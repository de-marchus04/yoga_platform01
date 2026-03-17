using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace Yoga.Client.Services
{
    public class UserAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _js;
        private const string TokenKey = "yl-user-token";

        public UserAuthStateProvider(IJSRuntime js)
        {
            _js = js;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = await _js.InvokeAsync<string?>("localStorage.getItem", TokenKey);
                if (string.IsNullOrEmpty(token))
                    return Anonymous();

                var claims = ParseClaimsFromJwt(token);
                if (claims == null) return Anonymous();

                // Check expiry
                var expClaim = claims.FirstOrDefault(c => c.Type == "exp");
                if (expClaim != null && long.TryParse(expClaim.Value, out var exp))
                {
                    if (DateTimeOffset.FromUnixTimeSeconds(exp) <= DateTimeOffset.UtcNow)
                    {
                        await _js.InvokeVoidAsync("localStorage.removeItem", TokenKey);
                        return Anonymous();
                    }
                }

                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt")));
            }
            catch
            {
                return Anonymous();
            }
        }

        public void NotifyUserAuthentication(string token)
        {
            var claims = ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "jwt");
            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public void NotifyUserLogout()
        {
            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
        }

        private static AuthenticationState Anonymous() =>
            new(new ClaimsPrincipal(new ClaimsIdentity()));

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
    }
}
