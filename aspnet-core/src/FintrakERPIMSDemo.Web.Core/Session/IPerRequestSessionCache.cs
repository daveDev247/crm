using System.Threading.Tasks;
using FintrakERPIMSDemo.Sessions.Dto;

namespace FintrakERPIMSDemo.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
