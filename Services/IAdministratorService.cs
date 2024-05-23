using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public interface IAdministratorService
{
    Task<List<Administrator>> GetAdministratorsAsync();
    Task<Administrator> GetAdministratorByIdAsync(int id);
    Task AddAdministratorAsync(Administrator administrator);
    Task UpdateAdministratorAsync(Administrator administrator);
    Task DeleteAdministratorAsync(int id);
}

}
