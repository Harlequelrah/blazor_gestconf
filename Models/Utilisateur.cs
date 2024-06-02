using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace blazor_gestconf.Models
{
    public class Utilisateur:IdentityUser<int>
    {
        // public override int Id { get; set; }
        // [Column(TypeName = "varchar(150)"), Required]

        // public string Nom { get; set; }
        // [Column(TypeName = "varchar(255)"), Required]
        // public override string Email { get; set; }
        // [Column(TypeName = "varchar(255)"), Required]
        // public string MotDePasse { get; set; }
        public Utilisateur():base() { }

        // public Utilisateur(int id, string name, string email, string password)
        // {
        //     Id = id;
        //     Nom = name;
        //     Email = email;
        //     MotDePasse = password;
        // }
    }

}
