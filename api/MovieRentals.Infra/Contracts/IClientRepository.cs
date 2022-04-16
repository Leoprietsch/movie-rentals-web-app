using MovieRentals.Domain;

namespace MovieRentals.Infra.Contracts
{
  public interface IClientRepository
  {
    Client[] GetAll();
    Client Get(int id);
    Client Create(Client client);
    Client Update(Client client);
    void Delete(int id);
  }
}