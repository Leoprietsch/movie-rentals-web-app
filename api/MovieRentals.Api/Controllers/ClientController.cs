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
  public class ClientController : ControllerBase
  {
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _clientService;

    public ClientController(ILogger<ClientController> logger, IClientService clientService)
    {
      _logger = logger;
      _clientService = clientService;
    }

    [HttpGet]
    public ActionResult<Client[]> GetAll()
    {
      return Ok(_clientService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Client> Get(int id)
    {
      return Ok(_clientService.Get(id));
    }

    [HttpPost]
    public ActionResult<Client> Post([FromBody] ClientCommandModel clientCommandModel)
    {
      return Ok(_clientService.Create(new Client(clientCommandModel.Nome, clientCommandModel.CPF, clientCommandModel.DataNascimento.Value)));
    }

    [HttpPut("{id}")]
    public ActionResult<Client> Put(int id, [FromBody] ClientCommandModel clientCommandModel)
    {
      return Ok(_clientService.Update(id, new Client(clientCommandModel.Nome, clientCommandModel.CPF, clientCommandModel.DataNascimento.Value)));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      _clientService.Delete(id);
      return NoContent();
    }
  }
}
