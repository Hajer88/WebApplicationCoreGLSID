using Microsoft.AspNetCore.Identity;

namespace WebApplicationCoreGLSID.Models
{
    public class ApplicationUser :IdentityUser 
    {
        public string City { get; set; }
    }
}
