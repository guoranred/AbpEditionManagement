using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.EditionManagement.Localization;

namespace Volo.Abp.EditionManagement
{
    public class EditionManager : DomainService, IEditionManager
    {
        protected IEditionRepository EditionRepository { get; }
        protected IStringLocalizer<AbpEditionManagementResource> Localizer { get; }

        public EditionManager(
            IEditionRepository editionRepository,
            IStringLocalizer<AbpEditionManagementResource> localizer)
        {
            EditionRepository = editionRepository;
            Localizer = localizer;
        }

        public virtual async Task<Edition> CreateAsync(string displayName)
        {
            Check.NotNull(displayName, nameof(displayName));

            await ValidateNameAsync(displayName);
            return new Edition(GuidGenerator.Create(), displayName);
        }

        public virtual async Task ChangeDisplayNameAsync(Edition edition, string displayName)
        {
            Check.NotNull(edition, nameof(edition));
            Check.NotNull(displayName, nameof(displayName));

            await ValidateNameAsync(displayName, edition.Id);
            edition.SetDisplayName(displayName);
        }

        public virtual async Task<Edition> FindByDisplayNameAsync(string displayName)
        {
            return await EditionRepository.FindByDisplayNameAsync(displayName);
        }

        protected virtual async Task ValidateNameAsync(string displayName, Guid? expectedId = null)
        {
            var edition = await EditionRepository.FindByDisplayNameAsync(displayName);
            if (edition != null && edition.Id != expectedId)
            {
                throw new UserFriendlyException(Localizer["Edition.DuplicateName", displayName]);
            }
        }
    }
}