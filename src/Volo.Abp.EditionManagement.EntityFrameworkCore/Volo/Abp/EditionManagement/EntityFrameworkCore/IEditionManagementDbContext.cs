using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.Abp.EditionManagement.EntityFrameworkCore
{
    [ConnectionStringName(AbpEditionManagementDbProperties.ConnectionStringName)]
    public interface IEditionManagementDbContext : IEfCoreDbContext
    {
        DbSet<Edition> Editions { get; set; }
    }
}