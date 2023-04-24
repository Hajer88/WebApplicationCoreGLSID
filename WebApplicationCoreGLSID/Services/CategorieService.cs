using Microsoft.EntityFrameworkCore;
using WebApplicationCoreGLSID.Models;
using WebApplicationCoreGLSID.ServicesContracts;

namespace WebApplicationCoreGLSID.Services
{
    public class CategorieService : ICategorieService
    {
        private readonly AppDbContext _context;
        public CategorieService(AppDbContext _context)
        {
            this._context = _context;
        }

        public async Task<Categorie> Create(Categorie categorie)
        {
            //categorie.Id = Guid.NewGuid();
            _context.categories.Add(categorie);
            await _context.SaveChangesAsync();
            return categorie;
        }

        public async Task<List<Categorie>> GetAll()
        {
            return await _context.categories
                .ToListAsync();
        }

        public Categorie Edit(Guid id,Categorie c)
        {
            var categorieInDb = _context.categories.Find(id);
            categorieInDb.Name= c.Name;
            //_context.categories.Update(categorieInDb);
            _context.SaveChanges();
            return categorieInDb;
        }

        public void Delete(Guid id)
        {
            //var c = _context.sscategories
            //    .Where(c => c.categorie.Id == id)
            //    .ToList();
            //foreach(var item in c)
            //{
            //    _context.sscategories.Remove(item);
            //    _context.SaveChanges();
            //}
            var t = _context.categories.Find(id);
            _context.categories.Remove(t);
            _context.SaveChanges();
        }
    }
}
