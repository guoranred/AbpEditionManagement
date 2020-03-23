using Volo.Abp.Data;

namespace Volo.Abp.EditionManagement
{
    public static class AbpEditionManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "AbpEditionManagement";
    }
}