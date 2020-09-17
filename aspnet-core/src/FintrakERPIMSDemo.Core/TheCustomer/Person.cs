using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace FintrakERPIMSDemo.TheCustomer
{
	[Table("Persons")]
    public class Person : Entity , IMayHaveTenant
    {
			public int? TenantId { get; set; }
			

		[Required]
		[StringLength(PersonConsts.MaxNamesLength, MinimumLength = PersonConsts.MinNamesLength)]
		public virtual string Names { get; set; }
		
		[Required]
		[StringLength(PersonConsts.MaxaddressLength, MinimumLength = PersonConsts.MinaddressLength)]
		public virtual string address { get; set; }
		

    }
}