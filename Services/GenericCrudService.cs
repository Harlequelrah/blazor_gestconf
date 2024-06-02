using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;
using Microsoft.AspNetCore.Identity;
namespace blazor_gestconf.Services
{
    public abstract class GenericCrudService<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly UserManager<Utilisateur> _userManager;

        public GenericCrudService(AppDbContext context)
        {
            _context = context;
        }

        // Méthodes CRUD à implémenter dans les sous-classes
        public abstract Task<List<TEntity>> GetAllAsync();
        public abstract Task<bool> AddAsync(TEntity entity);
        public abstract Task<bool> UpdateAsync(TEntity entity);

        // Méthodes optionnelles, peuvent être surchargées par les classes dérivées
        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException("This method is not implemented in the base class.");
        }

        public virtual Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException("This method is not implemented in the base class.");
        }

        public virtual Task<TEntity> GetByIdsAsync(int id1, int id2)
        {
            throw new NotImplementedException("This method is not implemented in the base class.");
        }

        public virtual Task<bool> DeletesAsync(int id1, int id2)
        {
            throw new NotImplementedException("This method is not implemented in the base class.");
        }
    }
}
