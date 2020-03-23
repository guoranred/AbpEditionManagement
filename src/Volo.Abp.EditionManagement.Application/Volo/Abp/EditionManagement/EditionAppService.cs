using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.EditionManagement
{
    [Authorize(EditionManagementPermissionNames.Editions.Default)]
    public class EditionAppService : EditionManagementAppServiceBase, IEditionAppService
    {
        protected IEditionRepository EditionRepository { get; }
        protected IEditionManager EditionManager { get; }

        public EditionAppService(
            IEditionRepository editionRepository,
            IEditionManager editionManager)
        {
            EditionRepository = editionRepository;
            EditionManager = editionManager;
        }

        public virtual async Task<EditionDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Edition, EditionDto>(
                await EditionRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<EditionDto>> GetListAsync(GetEditionsInput input)
        {
            var count = await EditionRepository.GetCountAsync(input.Filter);
            var list = await EditionRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter);

            return new PagedResultDto<EditionDto>(
                count,
                ObjectMapper.Map<List<Edition>, List<EditionDto>>(list)
            );
        }

        [Authorize(EditionManagementPermissionNames.Editions.Create)]
        public virtual async Task<EditionDto> CreateAsync(EditionCreateDto input)
        {
            var edition = await EditionManager.CreateAsync(input.DisplayName);
            await EditionRepository.InsertAsync(edition);

            return ObjectMapper.Map<Edition, EditionDto>(edition);
        }

        [Authorize(EditionManagementPermissionNames.Editions.Update)]
        public virtual async Task<EditionDto> UpdateAsync(Guid id, EditionUpdateDto input)
        {
            var edition = await EditionRepository.GetAsync(id);
            await EditionManager.ChangeDisplayNameAsync(edition, input.DisplayName);
            await EditionRepository.UpdateAsync(edition);
            return ObjectMapper.Map<Edition, EditionDto>(edition);
        }

        [Authorize(EditionManagementPermissionNames.Editions.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            var edition = await EditionRepository.FindAsync(id);
            if (edition == null)
            {
                return;
            }

            await EditionRepository.DeleteAsync(edition);
        }
    }
}