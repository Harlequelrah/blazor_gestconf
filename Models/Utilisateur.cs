using Microsoft.AspNetCore.Identity;


namespace blazor_gestconf.Models
{
    public class Utilisateur:IdentityUser<int>
    {
        public bool IsActive { get; set; } = true;
        public Utilisateur():base() { }
    }

}
