using System.Collections.Generic;
using MovieRentals.Domain;
using MovieRentals.Infra.Contracts;
using OfficeOpenXml;

namespace MovieRentals.Service.Contracts
{
  public class ReportService : IReportService
  {
    private readonly IClientRepository _clientService;
    private readonly IMovieRepository _movieRepository;
    public ReportService(IClientRepository clientService, IMovieRepository movieRepository)
    {
      _clientService = clientService;
      _movieRepository = movieRepository;
    }

    public byte[] GenerateReportFile()
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
      using (var file = new ExcelPackage())
      {
        var overdueSheet = file.Workbook.Worksheets.Add("Clientes em atraso");
        overdueSheet.Cells["A1"].LoadFromCollection(_clientService.GetOverdueClients(), true);
        overdueSheet.Column(4).Style.Numberformat.Format = "dd/MM/yyyy";

        var mostRented = new List<Client>();
        mostRented.Add(_clientService.GetSecondClientWhoMostRented());

        var mostRentedSheet = file.Workbook.Worksheets.Add("Segundo cliente que mais alugou");
        mostRentedSheet.Cells["A1"].LoadFromCollection(mostRented, true);
        mostRentedSheet.Column(4).Style.Numberformat.Format = "dd/MM/yyyy";

        file.Save();
        return file.GetAsByteArray();
      }
    }
  }
}