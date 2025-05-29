using Microsoft.EntityFrameworkCore;
using PetShop.DataContext.Entities;

namespace PetShop.DataContext
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entities.Slider>().ToTable("Sliders");
        }
        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Product> Products { get; set; }

       

    }
}
