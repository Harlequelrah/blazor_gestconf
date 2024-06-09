using blazor_gestconf.Data;
using blazor_gestconf.Models;
using Microsoft.AspNetCore.Identity;

namespace blazor_gestconf.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<Utilisateur> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<Utilisateur> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
