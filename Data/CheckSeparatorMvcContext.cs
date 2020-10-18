using Microsoft.EntityFrameworkCore;
using CheckSeparatorMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CheckSeparatorMVC.Data
{
    public class CheckSeparatorMvcContext : IdentityDbContext
    {
        public CheckSeparatorMvcContext(DbContextOptions<CheckSeparatorMvcContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasOne(p => p.Check).WithMany(c => c.Products).HasForeignKey(c => c.CheckId);
            modelBuilder.Entity<Check>().HasMany(p => p.Products).WithOne(c => c.Check);

            modelBuilder.Entity<CheckUser>().HasOne(cu => cu.Check).WithMany(c => c.CheckUsers).HasForeignKey(c => c.CheckId);
            modelBuilder.Entity<CheckUser>().HasOne(cu => cu.User).WithMany(c => c.CheckUsers).HasForeignKey(c => c.UserId);

            modelBuilder.Entity<ProductUser>().HasOne(pu => pu.Product).WithMany(p => p.ProductUsers).HasForeignKey(pu => pu.ProductId);
            modelBuilder.Entity<ProductUser>().HasOne(pu => pu.User).WithMany(p => p.ProductUsers).HasForeignKey(pu => pu.UserId);

            modelBuilder.Entity<CheckUser>().HasKey(cu => new { cu.CheckId, cu.UserId });
            modelBuilder.Entity<ProductUser>().HasKey(pu => new { pu.ProductId, pu.UserId });
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CheckUser> checkUsers { get; set; }
        public DbSet<ProductUser> productUsers { get; set; }
    }
}
