

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using FintrakERPIMSDemo.DemoCustomer.Exporting;
using FintrakERPIMSDemo.DemoCustomer.Dtos;
using FintrakERPIMSDemo.Dto;
using Abp.Application.Services.Dto;
using FintrakERPIMSDemo.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FintrakERPIMSDemo.DemoCustomer
{
	[AbpAuthorize(AppPermissions.Pages_Customers)]
    public class CustomersAppService : FintrakERPIMSDemoAppServiceBase, ICustomersAppService
    {
		 private readonly IRepository<Customer> _customerRepository;
		 private readonly ICustomersExcelExporter _customersExcelExporter;
		 

		  public CustomersAppService(IRepository<Customer> customerRepository, ICustomersExcelExporter customersExcelExporter ) 
		  {
			_customerRepository = customerRepository;
			_customersExcelExporter = customersExcelExporter;
			
		  }

		 public async Task<PagedResultDto<GetCustomerForViewDto>> GetAll(GetAllCustomersInput input)
         {
			
			var filteredCustomers = _customerRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.FirstName.Contains(input.Filter) || e.SurName.Contains(input.Filter) || e.Email.Contains(input.Filter) || e.Address.Contains(input.Filter) || e.Phone.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.FirstNameFilter),  e => e.FirstName == input.FirstNameFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.SurNameFilter),  e => e.SurName == input.SurNameFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.EmailFilter),  e => e.Email == input.EmailFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.AddressFilter),  e => e.Address == input.AddressFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.PhoneFilter),  e => e.Phone == input.PhoneFilter)
						.WhereIf(input.MinBirthDateFilter != null, e => e.BirthDate >= input.MinBirthDateFilter)
						.WhereIf(input.MaxBirthDateFilter != null, e => e.BirthDate <= input.MaxBirthDateFilter);

			var pagedAndFilteredCustomers = filteredCustomers
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var customers = from o in pagedAndFilteredCustomers
                         select new GetCustomerForViewDto() {
							Customer = new CustomerDto
							{
                                FirstName = o.FirstName,
                                SurName = o.SurName,
                                Email = o.Email,
                                Address = o.Address,
                                Phone = o.Phone,
                                BirthDate = o.BirthDate,
                                Id = o.Id
							}
						};

            var totalCount = await filteredCustomers.CountAsync();

            return new PagedResultDto<GetCustomerForViewDto>(
                totalCount,
                await customers.ToListAsync()
            );
         }
		 
		 public async Task<GetCustomerForViewDto> GetCustomerForView(int id)
         {
            var customer = await _customerRepository.GetAsync(id);

            var output = new GetCustomerForViewDto { Customer = ObjectMapper.Map<CustomerDto>(customer) };
			
            return output;
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_Customers_Edit)]
		 public async Task<GetCustomerForEditOutput> GetCustomerForEdit(EntityDto input)
         {
            var customer = await _customerRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetCustomerForEditOutput {Customer = ObjectMapper.Map<CreateOrEditCustomerDto>(customer)};
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditCustomerDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_Customers_Create)]
		 protected virtual async Task Create(CreateOrEditCustomerDto input)
         {
            var customer = ObjectMapper.Map<Customer>(input);

			
			if (AbpSession.TenantId != null)
			{
				customer.TenantId = (int?) AbpSession.TenantId;
			}
		

            await _customerRepository.InsertAsync(customer);
         }

		 [AbpAuthorize(AppPermissions.Pages_Customers_Edit)]
		 protected virtual async Task Update(CreateOrEditCustomerDto input)
         {
            var customer = await _customerRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, customer);
         }

		 [AbpAuthorize(AppPermissions.Pages_Customers_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _customerRepository.DeleteAsync(input.Id);
         } 

		public async Task<FileDto> GetCustomersToExcel(GetAllCustomersForExcelInput input)
         {
			
			var filteredCustomers = _customerRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.FirstName.Contains(input.Filter) || e.SurName.Contains(input.Filter) || e.Email.Contains(input.Filter) || e.Address.Contains(input.Filter) || e.Phone.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.FirstNameFilter),  e => e.FirstName == input.FirstNameFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.SurNameFilter),  e => e.SurName == input.SurNameFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.EmailFilter),  e => e.Email == input.EmailFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.AddressFilter),  e => e.Address == input.AddressFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.PhoneFilter),  e => e.Phone == input.PhoneFilter)
						.WhereIf(input.MinBirthDateFilter != null, e => e.BirthDate >= input.MinBirthDateFilter)
						.WhereIf(input.MaxBirthDateFilter != null, e => e.BirthDate <= input.MaxBirthDateFilter);

			var query = (from o in filteredCustomers
                         select new GetCustomerForViewDto() { 
							Customer = new CustomerDto
							{
                                FirstName = o.FirstName,
                                SurName = o.SurName,
                                Email = o.Email,
                                Address = o.Address,
                                Phone = o.Phone,
                                BirthDate = o.BirthDate,
                                Id = o.Id
							}
						 });


            var customerListDtos = await query.ToListAsync();

            return _customersExcelExporter.ExportToFile(customerListDtos);
         }


    }
}