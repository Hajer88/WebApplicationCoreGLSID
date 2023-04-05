using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationCoreGLSID.Models;
using WebApplicationCoreGLSID.Models.ViewModels;

namespace WebApplicationCoreGLSID.Controllers
{
    public class ProduitController : Controller
    {
        private readonly AppDbContext _context;
        public IWebHostEnvironment webHostEnvironment;
        public ProduitController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment=webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.produits.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProduitVM model, IFormFile photo)
        {
            if (photo == null)
                return Content("File not uploaded");
            try
            {
                //Combine trois chaînes dans un seul path
                var path = Path.Combine(webHostEnvironment.WebRootPath, "images",
                photo.FileName);
                //fournit un stream pour la lecture et ecriture dans un fichier
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    photo.CopyTo(stream);
                    stream.Close();
                }
               // model.produit.FileName = photo.FileName;
                //Mapping entre Model et ViewModel
                var produit = new Produit
                {
                    Id = new Guid(),
                    Name = model.produit.Name,
                    DateAjoutProduit = model.produit.DateAjoutProduit,
                    FileName = photo.FileName,
                };
                _context.Add(produit);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
