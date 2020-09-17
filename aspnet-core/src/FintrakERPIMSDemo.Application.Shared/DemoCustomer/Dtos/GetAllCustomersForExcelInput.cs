using Abp.Application.Services.Dto;
using System;

namespace FintrakERPIMSDemo.DemoCustomer.Dtos
{
    public class GetAllCustomersForExcelInput
    {
		public string Filter { get; set; }

		public string FirstNameFilter { get; set; }

		public string SurNameFilter { get; set; }

		public string EmailFilter { get; set; }

		public string AddressFilter { get; set; }

		public string PhoneFilter { get; set; }

		public DateTime? MaxBirthDateFilter { get; set; }
		public DateTime? MinBirthDateFilter { get; set; }



    }
}