using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplicationCoreGLSID.Models;
using WebApplicationCoreGLSID.Models.DTO;
using WebApplicationCoreGLSID.ServicesContracts;

namespace WebApplicationCoreGLSID.Services
{
    public class CategorieService : ICategorieService
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;
        public CategorieService(AppDbContext _context, IMapper mapper)
        {
            this._context = _context;
            this.mapper = mapper;
        }

        public async Task<CategorieDTO> Create(CategorieDTO categorie)
        {
            var test = mapper.Map<Categorie>(categorie);
            //categorie.Id = Guid.NewGuid();
            _context.categories.Add(test);
            await _context.SaveChangesAsync();
            return categorie;
        }

        public async Task<List<CategorieDTO>> GetAll()
        {
            var c=  await _context.categories
                .ToListAsync();
            //Mapping manuel en utilisant query Syntax
            var c2 = from t in _context.categories
                     select new CategorieDTO()
                     {
                         Id = t.Id,
                         Name = t.Name,
                     };
            return mapper.Map<List<CategorieDTO>>(c);

        }

        public CategorieDTO Edit(Guid id,CategorieDTO c)
        {
            var categorieInDb = _context.categories.Find(id);
            var x = mapper.Map<CategorieDTO, Categorie>(c);
            categorieInDb.Name= x.Name;
            //_context.categories.Update(categorieInDb);
            _context.SaveChanges();
            return c;
        }

        public void Delete(Guid id)
        {
            //Dotnotation syntaxe
            var c = _context.sscategories
                //Immédiate
                .ToList();
            //Query Syntaxe 
            var c2 = from x in _context.sscategories
                         //Exécution différé
                     select x;
                     //Exécution immédiate 
                     //.Count();
            //_context.Add()
            //Exécution immédiate
            //méthode d'aggrégation max, min, sum, Average, count
            var test = c2.Count();
            //foreach(var item in c)
            //{
            //    _context.sscategories.Remove(item);
            //    _context.SaveChanges();
            //}
            var t = _context.categories.Find(id);
            _context.categories.Remove(t);
            _context.SaveChanges();

            //retourner toutes les catégories dont
            // le nom commence avec X
            //var startWithX= from c in _context.categories where(c=>c.name.startsWith('A')
            //select c;

        }
    }
}
