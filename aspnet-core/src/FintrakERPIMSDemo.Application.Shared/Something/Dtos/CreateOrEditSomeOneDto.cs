
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace FintrakERPIMSDemo.Something.Dtos
{
    public class CreateOrEditSomeOneDto : EntityDto<int?>
    {

		[Required]
		[StringLength(SomeOneConsts.MaxNamesLength, MinimumLength = SomeOneConsts.MinNamesLength)]
		public string Names { get; set; }
		
		
		[Required]
		[StringLength(SomeOneConsts.MaxemailLength, MinimumLength = SomeOneConsts.MinemailLength)]
		public string email { get; set; }
		
		

    }
}