using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace FintrakERPIMSDemo.DemoCustomer.Dtos
{
    public class GetCustomerForEditOutput
    {
		public CreateOrEditCustomerDto Customer { get; set; }


    }
}