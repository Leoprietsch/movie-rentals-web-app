using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieRentals.Api.Models.Request;
using MovieRentals.Domain;
using MovieRentals.Service.Contracts;

namespace MovieRentals.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class RentController : ControllerBase
  {
    private readonly IRentService _rentService;

    public RentController(IRentService rentService)
      => _rentService = rentService;

    [HttpGet]
    public ActionResult<Rent[]> GetAll()
      => Ok(_rentService.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Rent> Get(int id)
      => Ok(_rentService.Get(id));

    [HttpPost]
    public ActionResult<Rent> Post([FromBody] RentCommandModel rentCommandModel)
      => Ok(_rentService.Create(rentCommandModel.IdClient, rentCommandModel.IdMovie));

    [HttpPut("{id}")]
    public ActionResult<Rent> Put(int id, [FromBody] RentCommandModel rentCommandModel)
      => Ok(_rentService.Update(id, rentCommandModel.IdClient, rentCommandModel.IdMovie));

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      _rentService.Delete(id);
      return NoContent();
    }

    [HttpPut("{id}/return")]
    public ActionResult Return(int id)
      => Ok(_rentService.Return(id));
  }
}
