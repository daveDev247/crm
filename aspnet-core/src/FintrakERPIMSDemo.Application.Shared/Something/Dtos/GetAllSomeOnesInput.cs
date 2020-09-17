using Abp.Application.Services.Dto;
using System;

namespace FintrakERPIMSDemo.Something.Dtos
{
    public class GetAllSomeOnesInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }

		public string NamesFilter { get; set; }

		public string emailFilter { get; set; }



    }
}