using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.Abp.EditionManagement.EntityFrameworkCore
{
    public class EfCoreEditionRepository : EfCoreRepository<IEditionManagementDbContext, Edition, Guid>, IEditionRepository
    {
        public EfCoreEditionRepository(IDbContextProvider<IEditionManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task<Edition> FindByDisplayNameAsync(
            string displayName,
            CancellationToken cancellationToken = default)
        {
            return await DbSet
                .FirstOrDefaultAsync(t => t.DisplayName == displayName, GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Edition>> GetListAsync(
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            CancellationToken cancellationToken = default)
        {
            return await DbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    u =>
                        u.DisplayName.Contains(filter)
                )
                .OrderBy(sorting ?? nameof(Edition.DisplayName))
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            return await this
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    u =>
                        u.DisplayName.Contains(filter)
                ).CountAsync(GetCancellationToken(cancellationToken));
        }
    }
}