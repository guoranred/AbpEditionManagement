using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Volo.Abp.EditionManagement.MongoDB
{
    [ConnectionStringName(AbpEditionManagementDbProperties.ConnectionStringName)]
    public interface IEditionManagementMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<Edition> Editions { get; }
    }
}