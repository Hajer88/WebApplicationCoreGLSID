using System.ComponentModel.DataAnnotations;

namespace WebApplicationCoreGLSID.Models
{
    public class Categorie
    {
        public Guid Id { get; set; }
        [Display(Name ="Nom de la Categorie")]
        public string Name { get; set; }
    }
}
