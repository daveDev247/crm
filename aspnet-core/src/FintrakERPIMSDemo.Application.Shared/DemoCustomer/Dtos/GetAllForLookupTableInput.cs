using Abp.Application.Services.Dto;

namespace FintrakERPIMSDemo.DemoCustomer.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }
    }
}