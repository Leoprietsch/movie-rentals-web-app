using MovieRentals.Domain;

namespace MovieRentals.Service.Contracts
{
  public interface IMovieService
  {
    Movie[] GetAll();
    Movie Create(Movie movie);
  }
}