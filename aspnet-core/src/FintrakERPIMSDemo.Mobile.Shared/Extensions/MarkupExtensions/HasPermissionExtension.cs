﻿using System;
using FintrakERPIMSDemo.Core;
using FintrakERPIMSDemo.Core.Dependency;
using FintrakERPIMSDemo.Services.Permission;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FintrakERPIMSDemo.Extensions.MarkupExtensions
{
    [ContentProperty("Text")]
    public class HasPermissionExtension : IMarkupExtension
    {
        public string Text { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ApplicationBootstrapper.AbpBootstrapper == null || Text == null)
            {
                return false;
            }

            var permissionService = DependencyResolver.Resolve<IPermissionService>();
            return permissionService.HasPermission(Text);
        }
    }
}