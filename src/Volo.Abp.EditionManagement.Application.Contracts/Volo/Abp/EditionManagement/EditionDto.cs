using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.EditionManagement
{
    public class EditionDto : EntityDto<Guid>
    {
        public string DisplayName { get; set; }
    }
}