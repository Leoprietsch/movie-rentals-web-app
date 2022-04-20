using Microsoft.AspNetCore.Mvc;
using MovieRentals.Service.Contracts;

namespace MovieRentals.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ReportController : ControllerBase
  {
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
      => _reportService = reportService;

    [HttpGet]
    public IActionResult GetExcel()
    {
      var fileData = _reportService.GenerateReportFile();
      var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
      var fileName = "relatorio.xlsx";

      return File(fileData, contentType, fileName);
    }
  }
}
