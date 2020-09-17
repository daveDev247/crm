using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using FintrakERPIMSDemo.DataExporting.Excel.NPOI;
using FintrakERPIMSDemo.TheCustomer.Dtos;
using FintrakERPIMSDemo.Dto;
using FintrakERPIMSDemo.Storage;

namespace FintrakERPIMSDemo.TheCustomer.Exporting
{
    public class PersonsExcelExporter : NpoiExcelExporterBase, IPersonsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public PersonsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
			ITempFileCacheManager tempFileCacheManager) :  
	base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetPersonForViewDto> persons)
        {
            return CreateExcelPackage(
                "Persons.xlsx",
                excelPackage =>
                {
                    
                    var sheet = excelPackage.CreateSheet(L("Persons"));

                    AddHeader(
                        sheet,
                        L("Names"),
                        L("address")
                        );

                    AddObjects(
                        sheet, 2, persons,
                        _ => _.Person.Names,
                        _ => _.Person.address
                        );

					
					
                });
        }
    }
}
