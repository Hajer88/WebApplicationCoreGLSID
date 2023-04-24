using WebApplicationCoreGLSID.Models;
using WebApplicationCoreGLSID.Models.DTO;

namespace WebApplicationCoreGLSID.ServicesContracts
{
    public interface ICategorieService
    {
        Task<List<CategorieDTO>> GetAll();
        Task<CategorieDTO> Create(CategorieDTO categorie);
        CategorieDTO Edit(Guid id, CategorieDTO c);
        void Delete(Guid id);
    }
}
