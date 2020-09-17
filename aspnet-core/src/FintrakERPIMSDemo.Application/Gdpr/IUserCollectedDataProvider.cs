using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using FintrakERPIMSDemo.Dto;

namespace FintrakERPIMSDemo.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
