using Microsoft.EntityFrameworkCore;

namespace p0
{
    /// <summary>
    /// Main entry point for interacting with the database
    /// </summary>
    public class BusinessContext : DbContext
    {
        /// <summary>
        /// Empty constructor for majority (non-testing) of uses
        /// </summary>
        public BusinessContext()
        {
        }

        /// <summary>
        /// Allows for configurable options for this context
        /// </summary>
        /// <param name="options">The options to configure</param>
        public BusinessContext(DbContextOptions<BusinessContext> options) : base(options)
        {
        }

        // Public DbSets required by EF Core
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Configures the context to use a specific database if no options are set
        /// </summary>
        /// <param name="options">The options to check if configured</param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source = business.db");
            }
        }
    }
}
