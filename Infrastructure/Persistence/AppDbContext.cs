using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Company> Companies { get; set; }  // This should be the actual entity, not a configuration
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<StockMovement>  StockMovements { get; set; }
        public DbSet<Customer>   Customers { get; set; }
        public DbSet<Sale>   Sales { get; set; }
        public DbSet<SaleItem>    SaleItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all configurations automatically from the assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // Convert all table names to lowercase
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var currentName = entity.GetTableName();
                if (!string.IsNullOrEmpty(currentName))
                    entity.SetTableName(currentName.ToLower());
            }
        }
    }
}
