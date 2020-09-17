﻿using Microsoft.AspNetCore.Antiforgery;

namespace FintrakERPIMSDemo.Web.Controllers
{
    public class AntiForgeryController : FintrakERPIMSDemoControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
