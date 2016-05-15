using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Retail.Models
{
    public class RetailContext : IdentityDbContext<RetailUser>
    {
        public void RunMigrations(bool recreateDatabase = false)
        {
            if (recreateDatabase)
            {
                Database.EnsureDeleted();
            }
            Database.Migrate();
        }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Price> Prices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Startup.Configuration["Data:DefaultConnection:ConnectionString"];
            
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

    }
}
