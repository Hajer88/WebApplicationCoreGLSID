using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationCoreGLSID.Models;

namespace WebApplicationCoreGLSID.Controllers
{
    public class SousCategorieController : Controller
    {
        private readonly AppDbContext _context;
        public SousCategorieController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Create()
        {
            var c = _context.categories.ToList();
            ViewBag.Categories = c.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SousCategorie sscat)
        {

            if (!ModelState.IsValid)
            {
                List<Categorie> cat = _context.categories.ToList();
                //ViewBag est utilisé pour transférer des données temporaires (non inclus dans
                //le modèle) du contrôleur à la vue.
                ViewBag.Categories = cat.Select(c
                => new SelectListItem()
                {
                    Text = c.Name //texte à afficher de la selectList
                ,
                    Value = c.Id.ToString() //Valeur de la selectList
                });
                return View();
            }
            sscat.Id = Guid.NewGuid();
            _context.sscategories.Add(sscat);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    
        public IActionResult Index()
        {
            return View(_context.sscategories.Include(c=>c.categorie).ToList());
        }
    }
}
