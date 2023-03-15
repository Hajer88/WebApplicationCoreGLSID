using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCoreGLSID.Controllers
{
    public class CategorieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
