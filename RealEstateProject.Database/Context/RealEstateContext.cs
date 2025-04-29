using Microsoft.EntityFrameworkCore;
using RealEstateManager.Database.Models;

namespace RealEstateManager.Database.Context
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options)
        {
            

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("RealEstateGraph");
        //}
        
        public DbSet<Property> Properties { get; set; }
        public DbSet<Payment> Payments { get; set; }

    }
}
