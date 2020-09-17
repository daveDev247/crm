using System;
using Abp.AutoMapper;
using FintrakERPIMSDemo.Sessions.Dto;

namespace FintrakERPIMSDemo.Models.Common
{
    [AutoMapFrom(typeof(ApplicationInfoDto)),
     AutoMapTo(typeof(ApplicationInfoDto))]
    public class ApplicationInfoPersistanceModel
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}