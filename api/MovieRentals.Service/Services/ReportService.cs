using OfficeOpenXml;

namespace MovieRentals.Service.Contracts
{
  public class ReportService : IReportService
  {
    public byte[] GenerateReportFile()
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
      using (var file = new ExcelPackage())
      {
        var sheet = file.Workbook.Worksheets.Add("My Sheet");
        sheet.Cells["A1"].Value = "Relatório";

        file.Save();
        return file.GetAsByteArray();
      }
    }
  }
}