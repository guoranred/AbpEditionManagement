using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.Abp.EditionManagement.EntityFrameworkCore
{
    [ConnectionStringName(AbpEditionManagementDbProperties.ConnectionStringName)]
    public class EditionManagementDbContext : AbpDbContext<EditionManagementDbContext>, IEditionManagementDbContext
    {
        public DbSet<Edition> Editions { get; set; }

        public EditionManagementDbContext(DbContextOptions<EditionManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureEditionManagement();
        }
    }
}