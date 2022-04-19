using MovieRentals.Domain;
using MovieRentals.Infra.Contracts;
using MovieRentals.Service.Contracts;

namespace MovieRentals.Service.Services
{
  public class MovieService : IMovieService
  {
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
      => _movieRepository = movieRepository;

    public Movie[] GetAll()
      => _movieRepository.GetAll();

    public Movie Create(Movie movie)
      => _movieRepository.Create(movie);
  }
}