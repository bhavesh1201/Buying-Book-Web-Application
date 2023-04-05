using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
            
        }

        public DbSet <Category> categories { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1 , Name="Samsung", DisplayOrder=1},
                new Category { Id = 2, Name = "Ol", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Micromax", DisplayOrder = 3 },

                new Category { Id = 4, Name = "Tenor", DisplayOrder = 4 }

                );

        }
    }
}
