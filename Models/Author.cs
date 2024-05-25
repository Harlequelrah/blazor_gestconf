using blazor_gestconf.Services;
using System.Collections.Generic;

namespace blazor_gestconf.Models
{
    public class Author : User
    {

        public string? University { get; set; }
        public string? Entreprise { get; set; }
        public ICollection<ArticleAuthor> Articles { get; set; } = new List<ArticleAuthor>();

        public Author(int id, string name, string email, string password, string university, string entreprise)
            : base(id, name, email, password)
        {
            University = university;
            Entreprise = entreprise;
        }

        public Author():base(){
        }


    }
}
