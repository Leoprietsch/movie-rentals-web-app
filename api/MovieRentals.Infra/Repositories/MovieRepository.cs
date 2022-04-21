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
    public MovieRepository(IDbConnection db)
      => _db = db;

    public Movie[] GetAll()
      => _db.Query<Movie>(@"
        SELECT
          id,
          titulo,
          classificacaoIndicativa,
          lancamento
        FROM filme")?.ToArray();

    public Movie Get(int id)
      => _db.QueryFirstOrDefault<Movie>(@"
        SELECT
          id,
          titulo,
          classificacaoIndicativa,
          lancamento
        FROM filme
        WHERE id = @Id", new { Id = id });

    public Movie Create(Movie movie)
    {
      _db.Query(@"
        INSERT INTO filme 
          (Id, Titulo, ClassificacaoIndicativa, Lancamento)
          VALUES 
          (@Id, @Titulo, @ClassificacaoIndicativa, @Lancamento);", movie);

      return movie;
    }

    public Movie[] GetMoviesNeverRented()
      => _db.Query<Movie>(@"
        SELECT *
          FROM filme
          WHERE id NOT IN
            (SELECT id_filme 
            FROM locacao);")?.ToArray();

    public Movie[] GetFiveMostRentedMoviesFromLastYear()
    => _db.Query<Movie>(@"
        SELECT
          f.Id,
          f.Titulo,
          f.ClassificacaoIndicativa,
          f.Lancamento,
          (SELECT Count(*) FROM locacao l WHERE l.id_filme = f.id AND l.dataLocacao > (NOW() - INTERVAL 1 YEAR)) as VezesAlugado
        FROM filme f
        ORDER BY VezesAlugado desc
        LIMIT 5;")?.ToArray();

    public Movie[] GetThreeLeastRentedMoviesFromLastWeek()
      => _db.Query<Movie>(@"
        SELECT
          f.Id,
          f.Titulo,
          f.ClassificacaoIndicativa,
          f.Lancamento,
          (SELECT Count(*) FROM locacao l WHERE l.id_filme = f.id AND l.dataLocacao > (NOW() - INTERVAL 1 WEEK)) as VezesAlugado
        FROM filme f
        ORDER BY VezesAlugado
        LIMIT 3;")?.ToArray();
  }
}