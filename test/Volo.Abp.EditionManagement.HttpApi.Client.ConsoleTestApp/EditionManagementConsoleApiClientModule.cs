using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Volo.Abp.EditionManagement
{
    [DependsOn(
        typeof(AbpEditionManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class EditionManagementConsoleApiClientModule : AbpModule
    {
        
    }
}
