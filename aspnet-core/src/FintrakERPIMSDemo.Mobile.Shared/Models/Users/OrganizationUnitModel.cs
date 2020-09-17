using Abp.AutoMapper;
using FintrakERPIMSDemo.Organizations.Dto;

namespace FintrakERPIMSDemo.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}