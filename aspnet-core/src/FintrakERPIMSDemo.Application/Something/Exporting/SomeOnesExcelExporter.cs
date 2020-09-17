using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using FintrakERPIMSDemo.DataExporting.Excel.NPOI;
using FintrakERPIMSDemo.Something.Dtos;
using FintrakERPIMSDemo.Dto;
using FintrakERPIMSDemo.Storage;

namespace FintrakERPIMSDemo.Something.Exporting
{
    public class SomeOnesExcelExporter : NpoiExcelExporterBase, ISomeOnesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public SomeOnesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
			ITempFileCacheManager tempFileCacheManager) :  
	base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetSomeOneForViewDto> someOnes)
        {
            return CreateExcelPackage(
                "SomeOnes.xlsx",
                excelPackage =>
                {
                    
                    var sheet = excelPackage.CreateSheet(L("SomeOnes"));

                    AddHeader(
                        sheet,
                        L("Names"),
                        L("email")
                        );

                    AddObjects(
                        sheet, 2, someOnes,
                        _ => _.SomeOne.Names,
                        _ => _.SomeOne.email
                        );

					
					
                });
        }
    }
}
