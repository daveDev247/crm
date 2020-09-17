using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace FintrakERPIMSDemo.DemoCustomer
{
	[Table("Customers")]
    public class Customer : Entity , IMayHaveTenant
    {
			public int? TenantId { get; set; }
			

		[Required]
		[StringLength(CustomerConsts.MaxFirstNameLength, MinimumLength = CustomerConsts.MinFirstNameLength)]
		public virtual string FirstName { get; set; }
		
		[Required]
		[StringLength(CustomerConsts.MaxSurNameLength, MinimumLength = CustomerConsts.MinSurNameLength)]
		public virtual string SurName { get; set; }
		
		[Required]
		[StringLength(CustomerConsts.MaxEmailLength, MinimumLength = CustomerConsts.MinEmailLength)]
		public virtual string Email { get; set; }
		
		[Required]
		[StringLength(CustomerConsts.MaxAddressLength, MinimumLength = CustomerConsts.MinAddressLength)]
		public virtual string Address { get; set; }
		
		[Required]
		[StringLength(CustomerConsts.MaxPhoneLength, MinimumLength = CustomerConsts.MinPhoneLength)]
		public virtual string Phone { get; set; }
		
		public virtual DateTime BirthDate { get; set; }
		

    }
}