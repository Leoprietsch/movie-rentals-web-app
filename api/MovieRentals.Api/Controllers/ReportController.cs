using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentals.Domain;
using MovieRentals.Service.Contracts;

namespace MovieRentals.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ReportController : ControllerBase
  {
    private readonly IMovieService _movieService;

    public ReportController(IMovieService clientService)
      => _movieService = clientService;

    [HttpGet]
    public ActionResult<Movie[]> GetAll()
      => Ok(_movieService.GetAll());

    [HttpPost]
    public ActionResult<Movie[]> Post([FromForm] IFormFile file)
    {
      var formatoPermitido = "text/csv";
      if (file.ContentType != formatoPermitido)
        return BadRequest($"Formato de arquivo deve ser {formatoPermitido}, mas foi enviado um {file.ContentType}");

      Stream stream = file.OpenReadStream();

      var importedMovies = _movieService.Import(stream);

      return importedMovies != null
        ? Ok(importedMovies)
        : UnprocessableEntity(new { Error = "Mensagem de erro" });
    }
  }
}
