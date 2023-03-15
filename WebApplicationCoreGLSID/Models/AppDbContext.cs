using Microsoft.EntityFrameworkCore;

namespace WebApplicationCoreGLSID.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }
        public DbSet<Categorie> categories { get; set; }
        public DbSet<SousCategorie> sscategories { get; set; }
        public DbSet<Produit> produits { get; set; }
        public DbSet<ImageProduit> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>().ToTable("Categs");
            modelBuilder.Entity<Categorie>()
                .Property(e => e.Name)
                .HasColumnType("varchar(20)")
                .HasDefaultValue("A");
            modelBuilder.Entity<SousCategorie>()
                .Property(c => c.Name)
                .HasColumnName("SSCatName")
                .HasMaxLength(255);
            modelBuilder.Entity<Categorie>()
                .HasData(
                new Categorie
                {
                    Id=new Guid("44cfbfd8-dbc8-4698-a9ed-2f2ffa1956dd"),
                    Name="Test"
                    
                });
            modelBuilder.Entity<SousCategorie>()
                .HasMany(c => c.produits)
                .WithMany(t => t.SousCategorie)
                .UsingEntity(j => j.ToTable("ProduitSsCategs"));
            //API FLuent pour une relation many to many en utilisant 
            //Table ProduitssCategs
            //modelBuilder.Entity<SousCategorie>()
            //   .HasMany(c => c.produits)
            //   .WithMany(t => t.SousCategorie)
            //   .UsingEntity<ProduitSsCategs>(j =>
            //   j.HasOne(c => c.produit)
            //   .WithMany(t => t.prodsscateg)
            //   .HasForeignKey(c => c.ProduitId),
            //   j =>
            //   j.HasOne(c => c.sscategorie)
            //   .WithMany(t => t.prodsscateg)
            //   .HasForeignKey(c => c.SousCategorieId),
            //    j =>
            //    {
            //        j.Property(pt => pt.DateAjoutProduit);
            //        j.HasKey(t => new { t.ProduitId, t.SousCategorieId });
            //    });


        }
    }
}
