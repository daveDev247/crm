using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FintrakERPIMSDemo.MultiTenancy.HostDashboard.Dto;

namespace FintrakERPIMSDemo.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}