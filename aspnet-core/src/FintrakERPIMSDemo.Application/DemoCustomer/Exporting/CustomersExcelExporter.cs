using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using FintrakERPIMSDemo.DataExporting.Excel.NPOI;
using FintrakERPIMSDemo.DemoCustomer.Dtos;
using FintrakERPIMSDemo.Dto;
using FintrakERPIMSDemo.Storage;

namespace FintrakERPIMSDemo.DemoCustomer.Exporting
{
    public class CustomersExcelExporter : NpoiExcelExporterBase, ICustomersExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public CustomersExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
			ITempFileCacheManager tempFileCacheManager) :  
	base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetCustomerForViewDto> customers)
        {
            return CreateExcelPackage(
                "Customers.xlsx",
                excelPackage =>
                {
                    
                    var sheet = excelPackage.CreateSheet(L("Customers"));

                    AddHeader(
                        sheet,
                        L("FirstName"),
                        L("SurName"),
                        L("Email"),
                        L("Address"),
                        L("Phone"),
                        L("BirthDate")
                        );

                    AddObjects(
                        sheet, 2, customers,
                        _ => _.Customer.FirstName,
                        _ => _.Customer.SurName,
                        _ => _.Customer.Email,
                        _ => _.Customer.Address,
                        _ => _.Customer.Phone,
                        _ => _timeZoneConverter.Convert(_.Customer.BirthDate, _abpSession.TenantId, _abpSession.GetUserId())
                        );

					
					for (var i = 1; i <= customers.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[6], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(6);
                });
        }
    }
}
