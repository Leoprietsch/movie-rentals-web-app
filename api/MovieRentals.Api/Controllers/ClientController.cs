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
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
     => _clientService = clientService;

    [HttpGet]
    public ActionResult<Client[]> GetAll()
      => Ok(_clientService.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Client> Get(int id)
      => Ok(_clientService.Get(id));

    [HttpPost]
    public ActionResult<Client> Post([FromBody] ClientCommandModel clientCommandModel)
      => Ok(_clientService.Create(new Client(clientCommandModel.Nome, clientCommandModel.CPF, clientCommandModel.DataNascimento.Value)));

    [HttpPut("{id}")]
    public ActionResult<Client> Put(int id, [FromBody] ClientCommandModel clientCommandModel)
      => Ok(_clientService.Update(id, new Client(clientCommandModel.Nome, clientCommandModel.CPF, clientCommandModel.DataNascimento.Value)));

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      _clientService.Delete(id);
      return NoContent();
    }
  }
}
