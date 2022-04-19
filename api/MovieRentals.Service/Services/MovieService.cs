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
          var records = csvReader.GetRecords<Movie>();

          var duplicates = records.GroupBy(x => x.Id).Where(g => g.Count() > 1);

          if (duplicates.Any())
            return null;

          return records.Select(movie =>
          {
            var existingMovie = _movieRepository.Get(movie.Id);
            return existingMovie ?? _movieRepository.Create(movie);
          }).ToArray();
        }
      }
    }
  }
}