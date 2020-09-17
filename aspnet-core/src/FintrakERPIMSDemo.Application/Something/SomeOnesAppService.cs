

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using FintrakERPIMSDemo.Something.Exporting;
using FintrakERPIMSDemo.Something.Dtos;
using FintrakERPIMSDemo.Dto;
using Abp.Application.Services.Dto;
using FintrakERPIMSDemo.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FintrakERPIMSDemo.Something
{
	[AbpAuthorize(AppPermissions.Pages_SomeOnes)]
    public class SomeOnesAppService : FintrakERPIMSDemoAppServiceBase, ISomeOnesAppService
    {
		 private readonly IRepository<SomeOne> _someOneRepository;
		 private readonly ISomeOnesExcelExporter _someOnesExcelExporter;
		 

		  public SomeOnesAppService(IRepository<SomeOne> someOneRepository, ISomeOnesExcelExporter someOnesExcelExporter ) 
		  {
			_someOneRepository = someOneRepository;
			_someOnesExcelExporter = someOnesExcelExporter;
			
		  }

		 public async Task<PagedResultDto<GetSomeOneForViewDto>> GetAll(GetAllSomeOnesInput input)
         {
			
			var filteredSomeOnes = _someOneRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Names.Contains(input.Filter) || e.email.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NamesFilter),  e => e.Names == input.NamesFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.emailFilter),  e => e.email == input.emailFilter);

			var pagedAndFilteredSomeOnes = filteredSomeOnes
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var someOnes = from o in pagedAndFilteredSomeOnes
                         select new GetSomeOneForViewDto() {
							SomeOne = new SomeOneDto
							{
                                Names = o.Names,
                                email = o.email,
                                Id = o.Id
							}
						};

            var totalCount = await filteredSomeOnes.CountAsync();

            return new PagedResultDto<GetSomeOneForViewDto>(
                totalCount,
                await someOnes.ToListAsync()
            );
         }
		 
		 public async Task<GetSomeOneForViewDto> GetSomeOneForView(int id)
         {
            var someOne = await _someOneRepository.GetAsync(id);

            var output = new GetSomeOneForViewDto { SomeOne = ObjectMapper.Map<SomeOneDto>(someOne) };
			
            return output;
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_SomeOnes_Edit)]
		 public async Task<GetSomeOneForEditOutput> GetSomeOneForEdit(EntityDto input)
         {
            var someOne = await _someOneRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetSomeOneForEditOutput {SomeOne = ObjectMapper.Map<CreateOrEditSomeOneDto>(someOne)};
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditSomeOneDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_SomeOnes_Create)]
		 protected virtual async Task Create(CreateOrEditSomeOneDto input)
         {
            var someOne = ObjectMapper.Map<SomeOne>(input);

			
			if (AbpSession.TenantId != null)
			{
				someOne.TenantId = (int?) AbpSession.TenantId;
			}
		

            await _someOneRepository.InsertAsync(someOne);
         }

		 [AbpAuthorize(AppPermissions.Pages_SomeOnes_Edit)]
		 protected virtual async Task Update(CreateOrEditSomeOneDto input)
         {
            var someOne = await _someOneRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, someOne);
         }

		 [AbpAuthorize(AppPermissions.Pages_SomeOnes_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _someOneRepository.DeleteAsync(input.Id);
         } 

		public async Task<FileDto> GetSomeOnesToExcel(GetAllSomeOnesForExcelInput input)
         {
			
			var filteredSomeOnes = _someOneRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Names.Contains(input.Filter) || e.email.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NamesFilter),  e => e.Names == input.NamesFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.emailFilter),  e => e.email == input.emailFilter);

			var query = (from o in filteredSomeOnes
                         select new GetSomeOneForViewDto() { 
							SomeOne = new SomeOneDto
							{
                                Names = o.Names,
                                email = o.email,
                                Id = o.Id
							}
						 });


            var someOneListDtos = await query.ToListAsync();

            return _someOnesExcelExporter.ExportToFile(someOneListDtos);
         }


    }
}