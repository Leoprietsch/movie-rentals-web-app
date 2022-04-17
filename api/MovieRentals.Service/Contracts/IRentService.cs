using MovieRentals.Domain;

namespace MovieRentals.Service.Contracts
{
  public interface IRentService
  {
    Rent[] GetAll();
    Rent Get(int id);
    Rent Create(int idClient, int idMovie);
    Rent Update(int id, int idClient, int idMovie);
    Rent Return(int id);
    void Delete(int id);
  }
}