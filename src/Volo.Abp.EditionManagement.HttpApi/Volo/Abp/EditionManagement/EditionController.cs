using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.EditionManagement
{
    [RemoteService]
    [Area("abp")]
    public class EditionController : AbpController, IEditionAppService
    {
        protected IEditionAppService EditionAppService { get; }

        public EditionController(IEditionAppService editionAppService)
        {
            EditionAppService = editionAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<EditionDto> GetAsync(Guid id)
        {
            return EditionAppService.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<EditionDto>> GetListAsync(GetEditionsInput input)
        {
            return EditionAppService.GetListAsync(input);
        }

        [HttpPost]
        public virtual Task<EditionDto> CreateAsync(EditionCreateDto input)
        {
            return EditionAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<EditionDto> UpdateAsync(Guid id, EditionUpdateDto input)
        {
            return EditionAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return EditionAppService.DeleteAsync(id);
        }
    }
}