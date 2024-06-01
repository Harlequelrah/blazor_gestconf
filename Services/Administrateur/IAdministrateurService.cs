namespace blazor_gestconf.Services.Administrateur
{
    public interface IAdministrateurService
    {
        public Task<List<Models.Administrateur>> GetAdmin();
        public Task<Models.Administrateur> GetAdminById(int id);
        public Task InsererUnAdmin(Models.Administrateur admin);
        public Task EditerUnAdmin(Models.Administrateur admin);
        public Task SupprimerUnAdmin(int id);
    }
}
