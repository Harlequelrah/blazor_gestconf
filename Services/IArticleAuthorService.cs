using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public interface IArticleAuthorService
{
    Task<List<ArticleAuthor>> GetArticleAuthorsAsync();
    Task<ArticleAuthor> GetArticleAuthorByIdAsync(int id);
    Task AddArticleAuthorAsync(ArticleAuthor ArticleAuthor);
    Task UpdateArticleAuthorAsync(ArticleAuthor ArticleAuthor);
    Task DeleteArticleAuthorAsync(int id);
}

}
