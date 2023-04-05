using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationCoreGLSID.Models
{
    public class Produit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public ICollection<ProduitSsCategs> prodsscateg { get; set; }
        public ICollection<SousCategorie>? SousCategorie { get; set; }
        public string? FileName { get; set; }
        public DateTime? DateAjoutProduit{ get; set; }
        //public Guid ImageProduitId { get; set; }
        //[ForeignKey("ImageProduitId")]
        //public ImageProduit? Image { get; set; }
    }
}
