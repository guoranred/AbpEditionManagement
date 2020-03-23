using Volo.Abp.Modularity;

namespace Volo.Abp.EditionManagement
{
    [DependsOn(
        typeof(AbpEditionManagementApplicationModule),
        typeof(EditionManagementDomainTestModule)
        )]
    public class EditionManagementApplicationTestModule : AbpModule
    {

    }
}
