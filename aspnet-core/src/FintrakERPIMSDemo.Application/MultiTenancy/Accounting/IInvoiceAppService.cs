﻿using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using FintrakERPIMSDemo.MultiTenancy.Accounting.Dto;

namespace FintrakERPIMSDemo.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
