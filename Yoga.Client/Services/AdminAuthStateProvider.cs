using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace Yoga.Client.Services
{
    public class AdminAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _js;
        private const string TokenKey = "yl-admin-token";

        public AdminAuthStateProvider(IJSRuntime js)
        {
            _js = js;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = await _js.InvokeAsync<string?>("localStorage.getItem", TokenKey);
                if (string.IsNullOrEmpty(token))
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

                var claims = ParseClaimsFromJwt(token);
                if (claims == null)
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

                // Check expiry
                var expClaim = claims.FirstOrDefault(c => c.Type == "exp");
                if (expClaim != null && long.TryParse(expClaim.Value, out var exp))
                {
                    var expDate = DateTimeOffset.FromUnixTimeSeconds(exp);
                    if (expDate <= DateTimeOffset.UtcNow)
                    {
                        await _js.InvokeVoidAsync("localStorage.removeItem", TokenKey);
                        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                    }
                }

                var identity = new ClaimsIdentity(claims, "jwt");
                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
            catch
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        public void NotifyUserAuthentication(string token)
        {
            var claims = ParseClaimsFromJwt(token);
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void NotifyUserLogout()
        {
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }

        private static IEnumerable<Claim>? ParseClaimsFromJwt(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.ReadJwtToken(token);
                return jwt.Claims;
            }
            catch
            {
                return null;
            }
        }
    }
}
