using Microsoft.EntityFrameworkCore;
using System.Configuration;
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
            string connectionstr = "Server = tcp:bclpc.database.windows.net,1433; Initial Catalog = TestDB; Persist Security Info = False; User ID = talha; Password = Test@123; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            optionsBuilder.UseSqlServer(connectionstr);
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }

}
