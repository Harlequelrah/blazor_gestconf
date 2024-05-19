namespace blazor_gestconf.Models
{
    public class Author : User
    {
        public string? University { get; set; }
        public string? Entreprise { get; set; }

        // Liste des articles associés à cet auteur
        public List<ArticleAuthor> Articles { get; set; }

        public Author() : base()
        {
            Articles = new List<ArticleAuthor>();
        }

        public Author(int id, string name, string email, string password, string university, string entreprise) : base(id, name, email, password)
        {
            this.University = university;
            this.Entreprise = entreprise;
            Articles = new List<ArticleAuthor>();
        }
    }
}
