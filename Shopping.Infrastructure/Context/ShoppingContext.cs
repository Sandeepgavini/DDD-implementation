using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Entities;

namespace Shopping.Infrastructure.Context
{
    public class ShoppingContext:DbContext
    {
        public ShoppingContext() { }

        public ShoppingContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingContext).Assembly);
        }
      
    }
}
