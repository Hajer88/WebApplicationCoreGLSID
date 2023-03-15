namespace WebApplicationCoreGLSID.Models
{
    public class ImageProduit
    {
        public Guid Id { get; set; }
        public byte[] Image { get; set; }
        public Produit? produit { get; set; }
    }
}
