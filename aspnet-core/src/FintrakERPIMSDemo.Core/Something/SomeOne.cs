using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace FintrakERPIMSDemo.Something
{
	[Table("SomeOnes")]
    public class SomeOne : Entity , IMayHaveTenant
    {
			public int? TenantId { get; set; }
			

		[Required]
		[StringLength(SomeOneConsts.MaxNamesLength, MinimumLength = SomeOneConsts.MinNamesLength)]
		public virtual string Names { get; set; }
		
		[Required]
		[StringLength(SomeOneConsts.MaxemailLength, MinimumLength = SomeOneConsts.MinemailLength)]
		public virtual string email { get; set; }
		

    }
}