using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Volo.Abp.EditionManagement.MongoDB
{
    [DependsOn(
        typeof(AbpEditionManagementDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class AbpEditionManagementMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<EditionManagementMongoDbContext>(options =>
            {
                options.AddDefaultRepositories<IEditionManagementMongoDbContext>();

                options.AddRepository<Edition, MongoEditionRepository>();
            });
        }
    }
}