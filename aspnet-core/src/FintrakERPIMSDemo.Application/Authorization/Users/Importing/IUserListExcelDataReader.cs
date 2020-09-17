using System.Collections.Generic;
using FintrakERPIMSDemo.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace FintrakERPIMSDemo.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
