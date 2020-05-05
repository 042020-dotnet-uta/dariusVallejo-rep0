using Microsoft.EntityFrameworkCore;

namespace p0
{
    public class BusinessContext : DbContext
    {
        public BusinessContext()
        {
        }

        public BusinessContext(DbContextOptions<BusinessContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source = business.db");
            }
        }
    }
}
