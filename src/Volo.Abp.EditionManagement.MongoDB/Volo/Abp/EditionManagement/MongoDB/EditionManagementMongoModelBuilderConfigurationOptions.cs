using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Volo.Abp.EditionManagement.MongoDB
{
    public class EditionManagementMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public EditionManagementMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}