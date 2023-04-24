using WebApplicationCoreGLSID.Models;

namespace WebApplicationCoreGLSID.ServicesContracts
{
    public interface ICategorieService
    {
        Task<List<Categorie>> GetAll();
        Task<Categorie> Create(Categorie categorie);
        Categorie Edit(Guid id, Categorie c);
        void Delete(Guid id);
    }
}
