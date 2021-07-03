using Microsoft.Extensions.Configuration;
using SD.BuildingBlocks.Repository;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces;
using WebApi.Infrastructure.Data;

namespace WebApi.Infrastructure.Repositories
{
    public class CandidatesRepositories : RepositoryEF<Candidates>, ICandidateRepository
    {
        private readonly CandidateDbContext dbContext;
        public IConfiguration Configuration;

        public CandidatesRepositories(CandidateDbContext _dbContext, IConfiguration _Configuration) : base(_dbContext)
        {
            dbContext = _dbContext;
            Configuration = _Configuration;
        }
    }
}
