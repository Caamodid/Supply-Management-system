using System;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // 1️⃣ Locate the appsettings.json file
            var basePath = Directory.GetCurrentDirectory();
            var jsonPath = Path.Combine(basePath, "appsettings.json");

            if (!File.Exists(jsonPath))
                throw new FileNotFoundException($"Could not find configuration file at {jsonPath}");

            // 2️⃣ Parse appsettings.json manually using System.Text.Json
            using var stream = File.OpenRead(jsonPath);
            using var document = JsonDocument.Parse(stream);

            var root = document.RootElement;
            string? connectionString = null;

            if (root.TryGetProperty("ConnectionStrings", out var csSection) &&
                csSection.TryGetProperty("DefaultConnection", out var csValue))
            {
                connectionString = csValue.GetString();
            }

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found in appsettings.json.");

            // 3️⃣ Build the DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(connectionString); // or UseSqlServer(connectionString);

            // 4️⃣ Return a new context instance
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
