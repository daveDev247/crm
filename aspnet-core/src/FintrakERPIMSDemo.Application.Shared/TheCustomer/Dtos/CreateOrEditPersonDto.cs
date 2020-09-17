
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace FintrakERPIMSDemo.TheCustomer.Dtos
{
    public class CreateOrEditPersonDto : EntityDto<int?>
    {

		[Required]
		[StringLength(PersonConsts.MaxNamesLength, MinimumLength = PersonConsts.MinNamesLength)]
		public string Names { get; set; }
		
		
		[Required]
		[StringLength(PersonConsts.MaxaddressLength, MinimumLength = PersonConsts.MinaddressLength)]
		public string address { get; set; }
		
		

    }
}