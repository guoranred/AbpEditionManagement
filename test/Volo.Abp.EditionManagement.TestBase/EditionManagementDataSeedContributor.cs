using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace Volo.Abp.EditionManagement
{
    public class EditionManagementDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        protected IGuidGenerator GuidGenerator { get; }

        public EditionManagementDataSeedContributor(
            IGuidGenerator guidGenerator)
        {
            GuidGenerator = guidGenerator;
        }
        
        public Task SeedAsync(DataSeedContext context)
        {
            /* Instead of returning the Task.CompletedTask, you can insert your test data
             * at this point!
             */

            return Task.CompletedTask;
        }
    }
}