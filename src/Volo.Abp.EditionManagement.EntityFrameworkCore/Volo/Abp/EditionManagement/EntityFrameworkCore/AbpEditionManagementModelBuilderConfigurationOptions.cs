using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Volo.Abp.EditionManagement.EntityFrameworkCore
{
    public class AbpEditionManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public AbpEditionManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {
        }
    }
}