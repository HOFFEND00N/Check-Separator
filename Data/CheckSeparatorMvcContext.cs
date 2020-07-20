using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CheckSeparatorMVC.Models;


namespace CheckSeparatorMVC.Data
{
    public class CheckSeparatorMvcContext : DbContext
    {
        public CheckSeparatorMvcContext(DbContextOptions<CheckSeparatorMvcContext> options) : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
    }
}
