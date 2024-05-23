using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public interface IArticleProofReaderService
{
    Task<List<ArticleProofReader>> GetArticleProofReadersAsync();
    Task<ArticleProofReader> GetArticleProofReaderByIdAsync(int id);
    Task AddArticleProofReaderAsync(ArticleProofReader ArticleProofReader);
    Task UpdateArticleProofReaderAsync(ArticleProofReader ArticleProofReader);
    Task DeleteArticleProofReaderAsync(int id);
}

}
