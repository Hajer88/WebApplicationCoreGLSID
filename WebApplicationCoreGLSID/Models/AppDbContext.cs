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
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>().ToTable("Categs");
           
        }
    }
}
