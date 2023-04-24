namespace WebApplicationCoreGLSID.Models
{
    public class SousCategorie
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public  Guid categorieId { get; set; }
        //Navigation properties
        public Categorie? categorie { get; set; }
        //public ICollection<ProduitSsCategs>? prodsscateg { get; set; }
        public  ICollection<Produit>? produits { get; set; }
    }
}
