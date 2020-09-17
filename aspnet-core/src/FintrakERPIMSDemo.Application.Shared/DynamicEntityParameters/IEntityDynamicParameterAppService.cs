using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using FintrakERPIMSDemo.DynamicEntityParameters.Dto;
using FintrakERPIMSDemo.EntityDynamicParameters;

namespace FintrakERPIMSDemo.DynamicEntityParameters
{
    public interface IEntityDynamicParameterAppService
    {
        Task<EntityDynamicParameterDto> Get(int id);

        Task<ListResultDto<EntityDynamicParameterDto>> GetAllParametersOfAnEntity(EntityDynamicParameterGetAllInput input);

        Task<ListResultDto<EntityDynamicParameterDto>> GetAll();

        Task Add(EntityDynamicParameterDto dto);

        Task Update(EntityDynamicParameterDto dto);

        Task Delete(int id);
    }
}
