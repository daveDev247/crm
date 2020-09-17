using System.Collections.Generic;
using FintrakERPIMSDemo.DemoCustomer.Dtos;
using FintrakERPIMSDemo.Dto;

namespace FintrakERPIMSDemo.DemoCustomer.Exporting
{
    public interface ICustomersExcelExporter
    {
        FileDto ExportToFile(List<GetCustomerForViewDto> customers);
    }
}