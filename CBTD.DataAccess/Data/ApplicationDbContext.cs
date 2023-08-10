using CBTD.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CBTD.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Non-Alcoholic Beverages", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Wine", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Snacks", DisplayOrder = 3 }
               );
               modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { Id = 1,Name = "Coca-Cola"},
                new Manufacturer { Id = 2,Name = "Alko"}
               );
        }

    }
}
