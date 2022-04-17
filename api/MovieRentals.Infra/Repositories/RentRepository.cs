using System;
using System.Data;
using System.Linq;
using Dapper;
using MovieRentals.Domain;
using MovieRentals.Infra.Contracts;

namespace MovieRentals.Infra.Repositories
{
  public class RentRepository : IRentRepository
  {
    private readonly IDbConnection _db;
    public RentRepository(IDbConnection db)
      => _db = db;

    public Rent[] GetAll()
    {
      Rent[] rents = _db.Query<Rent, Client, Movie, Rent>(@"
        SELECT
          l.id,
          l.dataLocacao,
          l.dataDevolucao,
          null AS splitClient,
          c.id,
          c.nome,
          c.CPF,
          c.dataNascimento,
          null AS splitMovie,
          f.id,
          f.titulo,
          f.classificacaoIndicativa,
          f.lancamento
        FROM locacao l
        INNER JOIN cliente c ON l.id_cliente = c.id
        INNER JOIN filme f ON l.id_filme = f.id", map: (rent, client, movie) =>
        {
          rent.Cliente = client;
          rent.Filme = movie;

          return rent;
        }, splitOn: "splitClient, splitMovie").ToArray();

      return rents;
    }

    public Rent Get(int id)
    {
      Rent rent = _db.Query<Rent, Client, Movie, Rent>(@"
        SELECT
          l.id,
          l.dataLocacao,
          l.dataDevolucao,
          null AS splitClient,
          c.id,
          c.nome,
          c.CPF,
          c.dataNascimento,
          null AS splitMovie,
          f.id,
          f.titulo,
          f.classificacaoIndicativa,
          f.lancamento
        FROM locacao l
        INNER JOIN cliente c ON l.id_cliente = c.id
        INNER JOIN filme f ON l.id_filme = f.id
        WHERE l.id = @Id", map: (rent, client, movie) =>
        {
          rent.Cliente = client;
          rent.Filme = movie;

          return rent;
        }, param: new { Id = id }, splitOn: "splitClient, splitMovie").FirstOrDefault();

      return rent;
    }

    public Rent Create(Rent rent)
    {
      int id = _db.QuerySingle<int>(@"
      INSERT INTO locacao 
        (id_cliente, id_filme, dataLocacao)
        VALUES 
        (@IdClient, @IdMovie, @DataLocacao);
      
      SELECT LAST_INSERT_ID();", new { IdClient = rent.Cliente.Id, IdMovie = rent.Filme.Id, DataLocacao = rent.DataLocacao });

      rent.Id = id;

      return rent;
    }

    public Rent Update(Rent rent)
    {
      int affectedRows = _db.Execute(@"
        UPDATE locacao set 
          id_cliente = @IdClient,
          id_filme = @IdMovie
        WHERE id = @Id", new { Id = rent.Id, IdClient = rent.Cliente.Id, IdMovie = rent.Filme.Id });


      if (affectedRows > 0)
        return Get(rent.Id);

      return null;
    }

    public void Delete(int id)
      => _db.Query(@"DELETE FROM locacao WHERE Id = @Id", new { Id = id });

    public Rent Return(int id)
    {
      int affectedRows = _db.Execute(@"
        UPDATE locacao set 
          DataDevolucao = @DataDevolucao
        WHERE id = @Id", new { Id = id, DataDevolucao = DateTime.UtcNow });

      return Get(id);
    }
  }
}