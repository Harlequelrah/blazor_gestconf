using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blazor_gestconf.Models
{
    public class User
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(150)"), Required]

        public string? Name { get; set; }
        [Column(TypeName = "varchar(255)"), Required]
        public string? Email { get; set; }
        [Column(TypeName = "varchar(255)"), Required]
        public string? Password { get; set; }
        public User() { }

        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }
    }

}
