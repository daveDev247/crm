using System.Collections.Generic;
using Abp;
using FintrakERPIMSDemo.Chat.Dto;
using FintrakERPIMSDemo.Dto;

namespace FintrakERPIMSDemo.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
