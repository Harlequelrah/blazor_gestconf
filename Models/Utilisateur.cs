using Microsoft.AspNetCore.Identity;


namespace blazor_gestconf.Models
{
    public class Utilisateur:IdentityUser<int>
    {
        public Utilisateur():base() { }
    }

}
