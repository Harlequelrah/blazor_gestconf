using Microsoft.AspNetCore.Identity;

namespace blazor_gestconf.Models
{
    // Définissez votre propre classe de rôle utilisant int comme type d'identifiant
    public class Role : IdentityRole<int>
    {
    }
}
