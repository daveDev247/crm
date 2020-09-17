using System.Threading.Tasks;
using FintrakERPIMSDemo.Views;
using Xamarin.Forms;

namespace FintrakERPIMSDemo.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
