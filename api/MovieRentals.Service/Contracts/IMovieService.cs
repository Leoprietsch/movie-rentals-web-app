using System.IO;
using MovieRentals.Domain;

namespace MovieRentals.Service.Contracts
{
  public interface IMovieService
  {
    Movie[] GetAll();
    Movie[] Import(Stream fileStream);
  }
}