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
            modelBuilder.Entity<Product>().HasOne(p => p.Check).WithMany(c => c.Products).HasForeignKey(c => c.CheckId);
            modelBuilder.Entity<Check>().HasMany(p => p.Products).WithOne(c => c.Check);

            modelBuilder.Entity<CheckUser>().HasOne(cu => cu.Check).WithMany(c => c.CheckUsers).HasForeignKey(c => c.CheckId);
            modelBuilder.Entity<CheckUser>().HasOne(cu => cu.User).WithMany(c => c.CheckUsers).HasForeignKey(c => c.UserId);

            modelBuilder.Entity<CheckUser>().HasKey(cu => new { cu.CheckId, cu.UserId });

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
