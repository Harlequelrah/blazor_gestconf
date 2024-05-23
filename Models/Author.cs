using blazor_gestconf.Services;
using System.Collections.Generic;

namespace blazor_gestconf.Models
{
    public class Author : User
    {
        private readonly IAuthorService _authorService;

        public string? University { get; set; }
        public string? Entreprise { get; set; }
        public ICollection<ArticleAuthor> Articles { get; set; } = new List<ArticleAuthor>(); 

        public Author(IAuthorService authorService) : base()
        {
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
        }

        public Author(int id, string name, string email, string password, string university, string entreprise, IAuthorService authorService)
            : base(id, name, email, password)
        {
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
            University = university;
            Entreprise = entreprise;
        }
    }
}
