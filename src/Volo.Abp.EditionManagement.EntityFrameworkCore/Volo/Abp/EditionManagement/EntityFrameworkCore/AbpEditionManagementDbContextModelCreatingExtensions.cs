using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Volo.Abp.EditionManagement.EntityFrameworkCore
{
    public static class AbpEditionManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureEditionManagement(
            this ModelBuilder builder,
            Action<AbpEditionManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new AbpEditionManagementModelBuilderConfigurationOptions(
                AbpEditionManagementDbProperties.DbTablePrefix,
                AbpEditionManagementDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<Edition>(b =>
            {
                b.ToTable(options.TablePrefix + "Editions", options.Schema);

                b.ConfigureFullAuditedAggregateRoot();

                b.Property(e => e.DisplayName).IsRequired().HasMaxLength(EditionConsts.MaxDisplayNameLength);

                b.HasIndex(e => e.DisplayName);
            });
        }
    }
}