using Volo.Abp.EditionManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Volo.Abp.EditionManagement
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(EditionManagementEntityFrameworkCoreTestModule)
        )]
    public class EditionManagementDomainTestModule : AbpModule
    {
        
    }
}
