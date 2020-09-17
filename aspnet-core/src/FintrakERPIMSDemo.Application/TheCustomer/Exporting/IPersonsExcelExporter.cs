using System.Collections.Generic;
using FintrakERPIMSDemo.TheCustomer.Dtos;
using FintrakERPIMSDemo.Dto;

namespace FintrakERPIMSDemo.TheCustomer.Exporting
{
    public interface IPersonsExcelExporter
    {
        FileDto ExportToFile(List<GetPersonForViewDto> persons);
    }
}