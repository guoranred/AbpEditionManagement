using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Volo.Abp.EditionManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpEditionManagementDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class AbpEditionManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<EditionManagementDbContext>(options =>
            {
                options.AddDefaultRepositories<IEditionManagementDbContext>();
            });
        }
    }
}