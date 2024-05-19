namespace blazor_gestconf.Models
{
    public class Author:User
    {
        public string? university { get; set;}
        public string? entreprise { get; set; }

        public Author() : base() { }
    }
}
