using Microsoft.AspNetCore.Mvc;
using WebApplicationCoreGLSID.Models;

namespace WebApplicationCoreGLSID.Controllers
{
    //CRUD Operations sur la classe du modèle 'Categorie'
    public class CategorieController : Controller
    {
        private readonly AppDbContext _context;
        public CategorieController(AppDbContext context)
        {
            _context = context;
        }
        [Route("Index")]
        //Lister tous les catégories
        public IActionResult Index()
        {
            return View(_context.categories.ToList());
        }
        [Route("DownloadFile")]
        public IActionResult DownloadFile()
        {
            byte[] bytes = System.IO.File
                .ReadAllBytes(@"C:\Users\TEK-UP\Desktop\Document.pdf");
            return File(bytes, "Application/pdf");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categorie c)
        {
            _context.categories.Add(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(Guid? id)
        {
            if (id == null) return NotFound();
            var categorie = _context.categories.FirstOrDefault(c => c.Id == id);
            return View(categorie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categorie c)
        {
            _context.categories.Update(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(Guid? id)
        {
            if (id == null) return NotFound();
            var c = _context.categories.Find(id);
            _context.categories.Remove(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ActionName("Delete")]
        //public IActionResult DeleteConfirmed(Guid? id)
        //{
        //    if(id== null) return NotFound();
        //    var c = _context.categories.Find(id);
        //    _context.categories.Remove(c);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
