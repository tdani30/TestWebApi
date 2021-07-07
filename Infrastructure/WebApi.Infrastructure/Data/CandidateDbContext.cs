using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Data
{
   public  class CandidateDbContext : DbContext
    {
        public virtual DbSet<Candidates> Candidates { get; set; }

       
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DotNetCoreConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }

}
