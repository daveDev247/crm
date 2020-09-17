using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using FintrakERPIMSDemo.Something.Dtos;
using FintrakERPIMSDemo.Dto;


namespace FintrakERPIMSDemo.Something
{
    public interface ISomeOnesAppService : IApplicationService 
    {
        Task<PagedResultDto<GetSomeOneForViewDto>> GetAll(GetAllSomeOnesInput input);

        Task<GetSomeOneForViewDto> GetSomeOneForView(int id);

		Task<GetSomeOneForEditOutput> GetSomeOneForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditSomeOneDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetSomeOnesToExcel(GetAllSomeOnesForExcelInput input);

		
    }
}