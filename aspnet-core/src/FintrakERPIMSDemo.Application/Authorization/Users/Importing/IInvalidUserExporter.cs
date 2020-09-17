using System.Collections.Generic;
using FintrakERPIMSDemo.Authorization.Users.Importing.Dto;
using FintrakERPIMSDemo.Dto;

namespace FintrakERPIMSDemo.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
