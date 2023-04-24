using WebApplicationCoreGLSID.Models;

namespace WebApplicationCoreGLSID.ServicesContracts
{
    public interface ISousCategorieService
    {
        IEnumerable<SousCategorie> GetAll();
        IEnumerable<SousCategorie> GetOrderBy();

        IEnumerable<SousCategorie> GetssCatByCatName(string name);

    }
}
