using Microsoft.AspNetCore.Mvc;
using FintrakERPIMSDemo.Web.Controllers;

namespace FintrakERPIMSDemo.Web.Public.Controllers
{
    public class HomeController : FintrakERPIMSDemoControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}