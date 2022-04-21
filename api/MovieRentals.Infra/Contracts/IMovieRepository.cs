using MovieRentals.Domain;

namespace MovieRentals.Infra.Contracts
{
  public interface IMovieRepository
  {
    Movie[] GetAll();
    Movie Get(int id);
    Movie Create(Movie movie);
    Movie[] GetMoviesNeverRented();
    Movie[] GetFiveMostRentedMoviesFromLastYear();
    Movie[] GetThreeLeastRentedMoviesFromLastWeek();
  }
}