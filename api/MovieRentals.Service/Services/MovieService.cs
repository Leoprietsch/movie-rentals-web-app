using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
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

    public Movie[] Import(Stream fileStream)
    {
      using (var reader = new StreamReader(fileStream))
      {
        using (var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.CurrentCulture)
        {
          Delimiter = ";"
        }))
        {
          var movies = csvReader.GetRecords<Movie>().ToList();

          var mvs = new List<Movie>(movies);
          var hasEmptyIds = mvs.Any(x => x.Id == null);
          var hasDuplicates = mvs.GroupBy(x => x.Id).Any(x => x.Count() > 1);

          if (hasDuplicates || hasEmptyIds) return null;

          var hasAnyExistingMovie = movies.Any(m => _movieRepository.Get(m.Id.Value) != null);
          if (hasAnyExistingMovie) return null;

          return movies.Select(movie => _movieRepository.Create(movie)).ToArray();
        }
      }
    }
  }
}