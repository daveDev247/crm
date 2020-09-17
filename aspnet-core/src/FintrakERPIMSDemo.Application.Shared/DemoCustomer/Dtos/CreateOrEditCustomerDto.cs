
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace FintrakERPIMSDemo.DemoCustomer.Dtos
{
    public class CreateOrEditCustomerDto : EntityDto<int?>
    {

		[Required]
		[StringLength(CustomerConsts.MaxFirstNameLength, MinimumLength = CustomerConsts.MinFirstNameLength)]
		public string FirstName { get; set; }
		
		
		[Required]
		[StringLength(CustomerConsts.MaxSurNameLength, MinimumLength = CustomerConsts.MinSurNameLength)]
		public string SurName { get; set; }
		
		
		[Required]
		[StringLength(CustomerConsts.MaxEmailLength, MinimumLength = CustomerConsts.MinEmailLength)]
		public string Email { get; set; }
		
		
		[Required]
		[StringLength(CustomerConsts.MaxAddressLength, MinimumLength = CustomerConsts.MinAddressLength)]
		public string Address { get; set; }
		
		
		[Required]
		[StringLength(CustomerConsts.MaxPhoneLength, MinimumLength = CustomerConsts.MinPhoneLength)]
		public string Phone { get; set; }
		
		
		public DateTime BirthDate { get; set; }
		
		

    }
}