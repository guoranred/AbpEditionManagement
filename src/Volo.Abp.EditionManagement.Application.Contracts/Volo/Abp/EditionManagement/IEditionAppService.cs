using System;
using Volo.Abp.Application.Services;

namespace Volo.Abp.EditionManagement
{
    public interface IEditionAppService : ICrudAppService<EditionDto, Guid, GetEditionsInput, EditionCreateDto, EditionUpdateDto>
    {
    }
}