using System.Collections.Generic;
using FintrakERPIMSDemo.Something.Dtos;
using FintrakERPIMSDemo.Dto;

namespace FintrakERPIMSDemo.Something.Exporting
{
    public interface ISomeOnesExcelExporter
    {
        FileDto ExportToFile(List<GetSomeOneForViewDto> someOnes);
    }
}