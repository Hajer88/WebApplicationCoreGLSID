using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCoreGLSID.Models;

namespace WebApplicationCoreGLSID.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _identity;
        public AccountController(UserManager<ApplicationUser> identity)
        {
            _identity = identity;
        }
        [AllowAnonymous]
    
        public IActionResult GetUsers()
        {
            return View(_identity.Users);
        }
    }
}
