using Microsoft.EntityFrameworkCore;
using WebApplicationCoreGLSID.Models;
using WebApplicationCoreGLSID.ServicesContracts;

namespace WebApplicationCoreGLSID.Services
{
    public class SousCategorieService : ISousCategorieService
    {
        private readonly AppDbContext _context;
        public SousCategorieService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SousCategorie> GetAll()
        {
            return _context.sscategories
                .Include(c=>c.categorie)
                .ToList();
        }

        public IEnumerable<SousCategorie> GetOrderBy()
        {
           var test=  _context.sscategories.OrderBy(c=>
            c.Name).ToList();
            return test;
        }

        public IEnumerable<SousCategorie> GetssCatByCatName(string name)
        {
            var test = _context.sscategories
                .Where(c => c.categorie.Name == name)
                .ToList();
            return test;
        }
        //Récupérer sous Categories par Ordre Decroissant
    }
}
