using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public abstract class GenericCrudService<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        private readonly ILogger? _logger;

        public GenericCrudService(AppDbContext context)
        {
            _context = context;
        }

        // Méthodes CRUD à implémenter dans les sous-classes
        public abstract Task<List<TEntity>> GetAllAsync();
        public abstract Task<TEntity> GetByIdAsync(int id);
        public abstract Task AddAsync(TEntity entity);
        public abstract Task UpdateAsync(TEntity entity);
        public abstract Task DeleteAsync(int id);
    }
}
