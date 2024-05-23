using blazor_gestconf.Services;
using System.Collections.Generic;

namespace blazor_gestconf.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FichierPdf { get; set; }
        public string Statut { get; set; }
        public int ConferenceId { get; set; }

        public ICollection<ArticleAuthor> Authors { get; set; } = new List<ArticleAuthor>();
        public ICollection<ArticleProofReader> ArticleProofReaders { get; set; } = new List<ArticleProofReader>();

        private readonly IArticleService _articleService;

        public Article(int id, string title, string description, string fichierPdf, string statut, int conferenceId, IArticleService articleService)
        {
            Id = id;
            Title = title;
            Description = description;
            FichierPdf = fichierPdf;
            Statut = statut;
            ConferenceId = conferenceId;
            _articleService = articleService;
        }
    }
}
