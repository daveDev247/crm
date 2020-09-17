using System.Threading.Tasks;

namespace FintrakERPIMSDemo.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}