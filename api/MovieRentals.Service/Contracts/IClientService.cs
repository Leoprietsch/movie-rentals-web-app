using MovieRentals.Domain;

namespace MovieRentals.Service.Contracts
{
  public interface IClientService
  {
    Client[] GetAll();
    Client Get(int id);
    Client Create(Client client);
    Client Update(Client client);
    void Delete(int id);
  }
}