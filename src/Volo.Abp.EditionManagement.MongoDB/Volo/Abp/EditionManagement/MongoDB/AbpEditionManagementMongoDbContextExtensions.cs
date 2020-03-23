using System;
using Volo.Abp.MongoDB;

namespace Volo.Abp.EditionManagement.MongoDB
{
    public static class AbpEditionManagementMongoDbContextExtensions
    {
        public static void ConfigureEditionManagement(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new EditionManagementMongoModelBuilderConfigurationOptions(
                AbpEditionManagementDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);

            builder.Entity<Edition>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Editions";
            });
        }
    }
}