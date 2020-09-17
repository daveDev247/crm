using Abp.Application.Services.Dto;
using System;

namespace FintrakERPIMSDemo.TheCustomer.Dtos
{
    public class GetAllPersonsForExcelInput
    {
		public string Filter { get; set; }

		public string NamesFilter { get; set; }

		public string addressFilter { get; set; }



    }
}