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

    public Client[] GetAll()
    {
      return _clientRepository.GetAll();
    }

    public Client Get(int id)
    {
      return _clientRepository.Get(id);
    }

    public Client Create(Client client)
    {
      return _clientRepository.Create(client);
    }

    public Client Update(int id, Client client)
    {
      return _clientRepository.Update(id, client);
    }

    public void Delete(int id)
    {
      _clientRepository.Delete(id);
    }
  }
}