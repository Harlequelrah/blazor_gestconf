using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blazor_gestconf.Data;
using blazor_gestconf.Models;

namespace  blazor_gestconf.Services
{
    public interface IConferenceService
{
    Task<List<Conference>> GetConferencesAsync();
    Task<Conference> GetConferenceByIdAsync(int id);
    Task AddConferenceAsync(Conference conference);
    Task UpdateConferenceAsync(Conference conference);
    Task DeleteConferenceAsync(int id);
}

}
