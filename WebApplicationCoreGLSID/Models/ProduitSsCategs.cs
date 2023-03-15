namespace WebApplicationCoreGLSID.Models
{
    public class ProduitSsCategs
    {
        public Guid ProduitId { get; set; }
        public Guid SousCategorieId { get; set; }
        public Produit produit { get; set; }
        public SousCategorie sscategorie { get; set; }
        public DateTime DateAjoutProduit { get; set; }
    }
}
