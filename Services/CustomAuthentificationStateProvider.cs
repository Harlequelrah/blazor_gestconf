using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace blazor_gestconf.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
        // Return the current user's authentication state
        return Task.FromResult(new AuthenticationState(_anonymous));
        }

    public void MarkUserAsAuthenticated(string username)
        {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, username)
            }, "apiauth"));

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(authenticatedUser)));
        }

    public void MarkUserAsLoggedOut()
        {
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
        }
    }
}
