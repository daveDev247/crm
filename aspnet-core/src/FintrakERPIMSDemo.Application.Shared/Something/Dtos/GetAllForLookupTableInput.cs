using Abp.Application.Services.Dto;

namespace FintrakERPIMSDemo.Something.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }
    }
}