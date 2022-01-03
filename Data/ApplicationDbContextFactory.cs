using Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data
{
    internal class ApplicationDbContextFactory : IDesignTimeDbContextFactory<AdamStoreDbContext>
    {
        public AdamStoreDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            var optionsBuilder = new DbContextOptionsBuilder();

            var connectionString = configuration
                        .GetConnectionString("eShopSolutionDb");

            optionsBuilder.UseSqlServer(connectionString);

            return new AdamStoreDbContext(optionsBuilder.Options);
        }
    }
}