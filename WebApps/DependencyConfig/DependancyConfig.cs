using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SD.BuildingBlocks.Infrastructure;
using SD.BuildingBlocks.Repository;
using WebApi.Domain.Interfaces;
using WebApi.Infrastructure;
using WebApi.Infrastructure.Repositories;
using WebApi.Interfaces;
using WebApi.Services.Services;

namespace WebApps.DependencyConfig
{
    public class DependancyConfig
    {
        private IServiceCollection _services;
        private IConfiguration _configuration;

        public DependancyConfig(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        public void ConfigureServices()
        {
            _services.AddScoped(typeof(IRepository<>), typeof(RepositoryEF<>));
            _services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            // register services
            _services.AddScoped<ICandidatesService, CandidateService>();

            // Register Application repositories.

            _services.AddScoped<ICandidateRepository, CandidatesRepositories>();


        }
    }
}
