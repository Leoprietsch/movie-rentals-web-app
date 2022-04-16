using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieRentals.Api.Models.Request;
using MovieRentals.Domain;

namespace MovieRentals.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ClienteController : ControllerBase
  {
    private readonly ILogger<ClienteController> _logger;

    public ClienteController(ILogger<ClienteController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public ActionResult<Client[]> GetAll()
    {
      return Ok(new Client[0]);
    }

    [HttpGet("{id}")]
    public ActionResult<Client> Get(int id)
    {
      return Ok();
    }

    [HttpPost]
    public ActionResult<Client> Post([FromBody] ClientCommandModel client)
    {
      return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult<Client> Put(int id, [FromBody] ClientCommandModel client)
    {
      return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      return NoContent();
    }
  }
}
