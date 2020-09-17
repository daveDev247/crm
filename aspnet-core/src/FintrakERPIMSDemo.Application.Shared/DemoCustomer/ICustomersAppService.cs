using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FintrakERPIMSDemo.DemoCustomer.Dtos;
using FintrakERPIMSDemo.Dto;


namespace FintrakERPIMSDemo.DemoCustomer
{
    public interface ICustomersAppService : IApplicationService 
    {
        Task<PagedResultDto<GetCustomerForViewDto>> GetAll(GetAllCustomersInput input);

        Task<GetCustomerForViewDto> GetCustomerForView(int id);

		Task<GetCustomerForEditOutput> GetCustomerForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditCustomerDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetCustomersToExcel(GetAllCustomersForExcelInput input);

		
    }
}