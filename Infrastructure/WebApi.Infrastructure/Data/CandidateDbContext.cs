using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Data
{
   public  class CandidateDbContext : DbContext
    {
        public virtual DbSet<Candidates> Candidates { get; set; }

        //public CandidateDbContext(DbContextOptions<CandidateDbContext> options) : base(options)
        //{

        //}
        //public CandidateDbContext() : base("name=SchoolDBConnectionString")
        //{

        //}
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionstr = "Data Source=DESKTOP-NR4U986\\SQLEXPRESS;Initial Catalog=TestApp;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
            optionsBuilder.UseSqlServer(connectionstr);
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer(GetConnectionString());
            //}
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }

}
