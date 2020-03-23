using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Volo.Abp.EditionManagement.MongoDB
{
    [ConnectionStringName(AbpEditionManagementDbProperties.ConnectionStringName)]
    public class EditionManagementMongoDbContext : AbpMongoDbContext, IEditionManagementMongoDbContext
    {
        public IMongoCollection<Edition> Editions => Collection<Edition>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureEditionManagement();
        }
    }
}