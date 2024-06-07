using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using Microsoft.AspNetCore.Identity;
using blazor_gestconf.Services;
using blazor_gestconf.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace blazor_gestconf.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly SignInManager<Utilisateur> signInManager;
    private readonly UserManager<Utilisateur> userManager;

    public CustomAuthenticationStateProvider(SignInManager<Utilisateur> signInManager, UserManager<Utilisateur> userManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = signInManager.Context.User;

        if (user?.Identity?.IsAuthenticated == true)
        {
            var claimsIdentity = (ClaimsIdentity)user.Identity;
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return new AuthenticationState(claimsPrincipal);
        }

        // Si l'utilisateur n'est pas authentifié, retourner un état non authentifié
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    public async Task SignInUserAsync(string userName)
    {
        var user = await userManager.FindByNameAsync(userName);
        if (user != null)
        {
            await signInManager.SignInAsync(user, isPersistent: false);
            Console.WriteLine($"User {userName} signed in successfully.");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        else
    {
        Console.WriteLine($"Failed to sign in user {userName}. User not found.");
    }
    }

    public void MarkUserAsLoggedOut()
    {
        signInManager.SignOutAsync();
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
    }
}

}
