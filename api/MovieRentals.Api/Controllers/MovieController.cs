using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieRentals.Api.Models.Request;
using MovieRentals.Domain;
using MovieRentals.Service.Contracts;

namespace MovieRentals.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MovieController : ControllerBase
  {
    private readonly IMovieService _movieService;

    public MovieController(IMovieService clientService)
      => _movieService = clientService;

    [HttpGet]
    public ActionResult<Movie[]> GetAll()
      => Ok(_movieService.GetAll());

    [HttpPost]
    public ActionResult<Rent> Post([FromBody] MovieCommandModel movieCommandModel)
      => Ok(_movieService.Create(new Movie(movieCommandModel.Id, movieCommandModel.Titulo, movieCommandModel.ClassificacaoIndicativa, movieCommandModel.Lancamento)));
  }
}
