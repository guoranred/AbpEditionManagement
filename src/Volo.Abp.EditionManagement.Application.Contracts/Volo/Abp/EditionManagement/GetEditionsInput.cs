using Volo.Abp.Application.Dtos;

namespace Volo.Abp.EditionManagement
{
    public class GetEditionsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}