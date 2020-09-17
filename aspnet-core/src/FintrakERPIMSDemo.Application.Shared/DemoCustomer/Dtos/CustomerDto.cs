
using System;
using Abp.Application.Services.Dto;

namespace FintrakERPIMSDemo.DemoCustomer.Dtos
{
    public class CustomerDto : EntityDto
    {
		public string FirstName { get; set; }

		public string SurName { get; set; }

		public string Email { get; set; }

		public string Address { get; set; }

		public string Phone { get; set; }

		public DateTime BirthDate { get; set; }



    }
}