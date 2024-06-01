using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blazor_gestconf.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(150)"), Required]

        public string Nom { get; set; }
        [Column(TypeName = "varchar(255)"), Required]
        public string Email { get; set; }
        [Column(TypeName = "varchar(255)"), Required]
        public string MotDePasse { get; set; }
        public Utilisateur() { }

        public Utilisateur(int id, string name, string email, string password)
        {
            Id = id;
            Nom = name;
            Email = email;
            MotDePasse = password;
        }
    }

}
