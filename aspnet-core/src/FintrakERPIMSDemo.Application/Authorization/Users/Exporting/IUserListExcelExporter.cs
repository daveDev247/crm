using System.Collections.Generic;
using FintrakERPIMSDemo.Authorization.Users.Dto;
using FintrakERPIMSDemo.Dto;

namespace FintrakERPIMSDemo.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}