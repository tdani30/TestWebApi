
using SD.BuildingBlocks.Infrastructure;
using System.Threading.Tasks;
using WebApi.Infrastructure.Data;

namespace WebApi.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private CandidateDbContext dbContext;
        public UnitOfWork(CandidateDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public int AffectedRows { get; private set; }

        public int Commit()
        {
            AffectedRows = dbContext.SaveChanges();
            return AffectedRows;
        }

        public async Task<int> CommitAsync()
        {
            AffectedRows = await dbContext.SaveChangesAsync();
            return AffectedRows;
        }
    }
}
