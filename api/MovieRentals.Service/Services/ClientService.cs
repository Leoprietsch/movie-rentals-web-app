using MovieRentals.Domain;
using MovieRentals.Infra.Contracts;
using MovieRentals.Service.Contracts;

namespace MovieRentals.Service.Services
{
  public class ClientService : IClientService
  {
    private readonly IClientRepository _clientRepository;
    public ClientService(IClientRepository clientRepository)
    {
      _clientRepository = clientRepository;
    }
    public Client Create(Client client)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Client Get(int id)
    {
      return _clientRepository.Get(id);
    }

    public Client[] GetAll()
    {
      throw new System.NotImplementedException();
    }

    public Client Update(Client client)
    {
      throw new System.NotImplementedException();
    }
  }
}