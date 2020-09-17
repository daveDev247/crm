using System.Collections.Generic;
using FintrakERPIMSDemo.Auditing.Dto;
using FintrakERPIMSDemo.Dto;

namespace FintrakERPIMSDemo.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
