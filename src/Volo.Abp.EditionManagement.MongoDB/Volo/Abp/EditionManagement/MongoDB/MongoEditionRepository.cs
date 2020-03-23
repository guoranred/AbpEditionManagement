using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Volo.Abp.EditionManagement.MongoDB
{
    public class MongoEditionRepository : MongoDbRepository<IEditionManagementMongoDbContext, Edition, Guid>, IEditionRepository
    {
        public MongoEditionRepository(IMongoDbContextProvider<IEditionManagementMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task<Edition> FindByDisplayNameAsync(
            string displayName,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(t => t.DisplayName == displayName, GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Edition>> GetListAsync(
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            string filter = null,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .WhereIf<Edition, IMongoQueryable<Edition>>(
                    !filter.IsNullOrWhiteSpace(),
                    u =>
                        u.DisplayName.Contains(filter)
                )
                .OrderBy(sorting ?? nameof(Edition.DisplayName))
                .As<IMongoQueryable<Edition>>()
                .PageBy<Edition, IMongoQueryable<Edition>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .WhereIf<Edition, IMongoQueryable<Edition>>(
                    !filter.IsNullOrWhiteSpace(),
                    u =>
                        u.DisplayName.Contains(filter)
                ).CountAsync(GetCancellationToken(cancellationToken));
        }
    }
}