using Microsoft.EntityFrameworkCore;

namespace blazor_gestconf.Services.Article
{
    public interface IArticleService
    {
        public Task<List<Models.Article>> GetArticles();

        public Task<Models.Article> GetArticleById(int id);

        public Task InsererUnArticle(Models.Article art);

        public Task EditerUnArticle(Models.Article art);

        public Task SupprimerUnArticle(int id);
    }
}
