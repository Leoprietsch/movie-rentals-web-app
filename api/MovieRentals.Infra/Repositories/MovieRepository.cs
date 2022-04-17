using System.Data;
using System.Linq;
using Dapper;
using MovieRentals.Domain;
using MovieRentals.Infra.Contracts;

namespace MovieRentals.Infra.Repositories
{
  public class MovieRepository : IMovieRepository
  {
    private readonly IDbConnection _db;
    public MovieRepository(IDbConnection db) => _db = db;

    public Movie[] GetAll()
    {
      return _db.Query<Movie>(@"
        SELECT
          id,
          titulo,
          classificacaoIndicativa,
          lancamento
        FROM filme")?.ToArray();
    }

    public Movie Get(int id)
    {
      return _db.QueryFirstOrDefault<Movie>(@"
        SELECT
          id,
          titulo,
          classificacaoIndicativa,
          lancamento
        FROM filme
        WHERE id = @Id", new { Id = id });
    }

    public Movie Create(Movie movie)
    {
      _db.QuerySingle<int>(@"
        INSERT INTO filme 
          (Id, Titulo, ClassificacaoIndicativa, Lancamento)
          VALUES 
          (@Id, @Titulo, @ClassificacaoIndicativa, @Lancamento);", movie);


      return movie;
    }
  }
}