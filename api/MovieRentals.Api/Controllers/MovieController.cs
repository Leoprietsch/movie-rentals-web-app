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
    private readonly IMovieService _clientService;

    public MovieController(IMovieService clientService)
      => _clientService = clientService;

    [HttpGet]
    public ActionResult<Movie[]> GetAll()
      => Ok(_clientService.GetAll());
  }
}
