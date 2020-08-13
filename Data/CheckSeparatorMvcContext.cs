using Microsoft.EntityFrameworkCore;
using CheckSeparatorMVC.Models;


namespace CheckSeparatorMVC.Data
{
    public class CheckSeparatorMvcContext : DbContext
    {
        public CheckSeparatorMvcContext(DbContextOptions<CheckSeparatorMvcContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Check_Product>()
                .HasKey(c => new { c.ProductId, c.CheckId, c.UserName});
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Check_Product> Check_Product { get; set; }
    }
}
