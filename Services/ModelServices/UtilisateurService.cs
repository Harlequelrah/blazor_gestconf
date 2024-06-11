
using Microsoft.AspNetCore.Authentication ;
using Microsoft.AspNetCore.Identity ;
using blazor_gestconf.Models;
using Microsoft.EntityFrameworkCore;
namespace blazor_gestconf.Services
{

public class UtilisateurService
{
    private readonly UserManager<Utilisateur> _userManager;

    public UtilisateurService(UserManager<Utilisateur> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<Utilisateur>> GetAllUsersAsync()
    {
        var allUsers = await _userManager.Users.ToListAsync();

            var filteredUsers = allUsers
                .Where(u => u.GetType().Name == "Auteur" || u.GetType().Name == "Participant" || u.GetType().Name == "Relecteur")
                .ToList();
            return filteredUsers;
    }

    public async Task SetUserActiveStatus(int Id, bool isActive)
    {
        string userId = Id.ToString();
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            user.IsActive = isActive;
            await _userManager.UpdateAsync(user);
        }
    }
}
}
