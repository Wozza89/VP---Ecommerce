using Microsoft.EntityFrameworkCore;
using Victoria.Plumbing.Models.DomainModels;

namespace Victoria.Plumbing.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>().HasKey(orders => orders.Id);
            modelBuilder.Entity<Orders>().HasOne(orders => orders.Customer);
            modelBuilder.Entity<Product>().HasKey(product => product.Id);
            modelBuilder.Entity<Orders>().HasKey(orders => orders.Id);
            modelBuilder.Entity<OrderItem>().HasKey(orders => orders.Id);
        }
    }
}
}
