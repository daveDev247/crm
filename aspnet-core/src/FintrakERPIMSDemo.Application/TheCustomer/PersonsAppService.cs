

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using FintrakERPIMSDemo.TheCustomer.Exporting;
using FintrakERPIMSDemo.TheCustomer.Dtos;
using FintrakERPIMSDemo.Dto;
using Abp.Application.Services.Dto;
using FintrakERPIMSDemo.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FintrakERPIMSDemo.TheCustomer
{
	[AbpAuthorize(AppPermissions.Pages_Persons)]
    public class PersonsAppService : FintrakERPIMSDemoAppServiceBase, IPersonsAppService
    {
		 private readonly IRepository<Person> _personRepository;
		 private readonly IPersonsExcelExporter _personsExcelExporter;
		 

		  public PersonsAppService(IRepository<Person> personRepository, IPersonsExcelExporter personsExcelExporter ) 
		  {
			_personRepository = personRepository;
			_personsExcelExporter = personsExcelExporter;
			
		  }

		 public async Task<PagedResultDto<GetPersonForViewDto>> GetAll(GetAllPersonsInput input)
         {
			
			var filteredPersons = _personRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Names.Contains(input.Filter) || e.address.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NamesFilter),  e => e.Names == input.NamesFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.addressFilter),  e => e.address == input.addressFilter);

			var pagedAndFilteredPersons = filteredPersons
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var persons = from o in pagedAndFilteredPersons
                         select new GetPersonForViewDto() {
							Person = new PersonDto
							{
                                Names = o.Names,
                                address = o.address,
                                Id = o.Id
							}
						};

            var totalCount = await filteredPersons.CountAsync();

            return new PagedResultDto<GetPersonForViewDto>(
                totalCount,
                await persons.ToListAsync()
            );
         }
		 
		 public async Task<GetPersonForViewDto> GetPersonForView(int id)
         {
            var person = await _personRepository.GetAsync(id);

            var output = new GetPersonForViewDto { Person = ObjectMapper.Map<PersonDto>(person) };
			
            return output;
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_Persons_Edit)]
		 public async Task<GetPersonForEditOutput> GetPersonForEdit(EntityDto input)
         {
            var person = await _personRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetPersonForEditOutput {Person = ObjectMapper.Map<CreateOrEditPersonDto>(person)};
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditPersonDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_Persons_Create)]
		 protected virtual async Task Create(CreateOrEditPersonDto input)
         {
            var person = ObjectMapper.Map<Person>(input);

			
			if (AbpSession.TenantId != null)
			{
				person.TenantId = (int?) AbpSession.TenantId;
			}
		

            await _personRepository.InsertAsync(person);
         }

		 [AbpAuthorize(AppPermissions.Pages_Persons_Edit)]
		 protected virtual async Task Update(CreateOrEditPersonDto input)
         {
            var person = await _personRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, person);
         }

		 [AbpAuthorize(AppPermissions.Pages_Persons_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _personRepository.DeleteAsync(input.Id);
         } 

		public async Task<FileDto> GetPersonsToExcel(GetAllPersonsForExcelInput input)
         {
			
			var filteredPersons = _personRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Names.Contains(input.Filter) || e.address.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NamesFilter),  e => e.Names == input.NamesFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.addressFilter),  e => e.address == input.addressFilter);

			var query = (from o in filteredPersons
                         select new GetPersonForViewDto() { 
							Person = new PersonDto
							{
                                Names = o.Names,
                                address = o.address,
                                Id = o.Id
							}
						 });


            var personListDtos = await query.ToListAsync();

            return _personsExcelExporter.ExportToFile(personListDtos);
         }


    }
}