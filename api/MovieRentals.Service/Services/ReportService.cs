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
        var overdueClientsSheet = file.Workbook.Worksheets.Add("Clientes em atraso na devolução"); ;
        overdueClientsSheet.Cells["A1"].LoadFromCollection(_clientService.GetOverdueClients(), true);
        overdueClientsSheet.Column(4).Style.Numberformat.Format = "dd/MM/yyyy";
        overdueClientsSheet.Columns.AutoFit();

        var moviesNeverRentedSheet = file.Workbook.Worksheets.Add("Filmes que nunca foram alugados");
        moviesNeverRentedSheet.Cells["A1"].LoadFromCollection(_movieRepository.GetMoviesNeverRented(), true);
        moviesNeverRentedSheet.Columns.AutoFit();

        var fiveMostRentedMoviesFromLastYearSheet = file.Workbook.Worksheets.Add("Cinco filmes mais alugados do último ano");
        fiveMostRentedMoviesFromLastYearSheet.Cells["A1"].LoadFromCollection(_movieRepository.GetFiveMostRentedMoviesFromLastYear(), true);
        fiveMostRentedMoviesFromLastYearSheet.Columns.AutoFit();

        var threeLeastRentedMoviesFromLastWeekSheet = file.Workbook.Worksheets.Add("Três filmes menos alugados da última semana");
        threeLeastRentedMoviesFromLastWeekSheet.Cells["A1"].LoadFromCollection(_movieRepository.GetThreeLeastRentedMoviesFromLastWeek(), true);
        threeLeastRentedMoviesFromLastWeekSheet.Columns.AutoFit();

        var mostRented = new List<Client>();
        mostRented.Add(_clientService.GetSecondClientWhoMostRented());
        var mostRentedSheet = file.Workbook.Worksheets.Add("O segundo cliente que mais alugou filmes.");
        mostRentedSheet.Cells["A1"].LoadFromCollection(mostRented, true);
        mostRentedSheet.Column(4).Style.Numberformat.Format = "dd/MM/yyyy";
        mostRentedSheet.Columns.AutoFit();

        file.Save();
        return file.GetAsByteArray();
      }
    }
  }
}