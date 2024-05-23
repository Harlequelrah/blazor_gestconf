using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace blazor_gestconf.Services
{
    public interface IRelectureService
{
    Task<List<Relecture>> GetRelecturesServiceAsync();
    Task<Relecture> GetRelectureServiceByIdAsync(int id);
    Task AddRelectureServiceAsync(Relecture relecture);
    Task UpdateRelectureServiceAsync(Relecture relecture);
    Task DeleteRelectureAsync(int id);
}

}
