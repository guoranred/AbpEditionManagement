using Volo.Abp.Modularity;

namespace Volo.Abp.EditionManagement
{
    [DependsOn(
        typeof(AbpEditionManagementDomainSharedModule)
        )]
    public class AbpEditionManagementDomainModule : AbpModule
    {
    }
}