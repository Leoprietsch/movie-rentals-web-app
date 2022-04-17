using MovieRentals.Domain;

namespace MovieRentals.Infra.Contracts
{
  public interface IRentRepository
  {
    Rent[] GetAll();
    Rent Get(int id);
    Rent Create(Rent rent);
    Rent Update(Rent rent);
    Rent Return(int id);
    void Delete(int id);
  }
}