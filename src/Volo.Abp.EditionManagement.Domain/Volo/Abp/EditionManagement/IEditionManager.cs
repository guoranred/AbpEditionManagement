using JetBrains.Annotations;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Volo.Abp.EditionManagement
{
    public interface IEditionManager : IDomainService
    {
        [NotNull]
        Task<Edition> CreateAsync([NotNull] string displayName);

        Task ChangeDisplayNameAsync([NotNull] Edition edition, [NotNull] string displayName);

        Task<Edition> FindByDisplayNameAsync(string displayName);
    }
}