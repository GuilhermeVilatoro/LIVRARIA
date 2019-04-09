using Livraria.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Livraria.Infra.Data.Context
{
    public class LivrariaContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new LivroMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use ver docker
            //optionsBuilder.UseInMemoryDatabase();

            optionsBuilder.UseSqlServer(config.GetConnectionString("LivrariaContext"));
        }
    }
}