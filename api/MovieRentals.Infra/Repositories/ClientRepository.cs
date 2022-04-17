using System.Data;
using System.Linq;
using Dapper;
using MovieRentals.Domain;
using MovieRentals.Infra.Contracts;

namespace MovieRentals.Infra.Repositories
{
  public class ClientRepository : IClientRepository
  {
    private readonly IDbConnection _db;
    public ClientRepository(IDbConnection db) => _db = db;

    public Client[] GetAll()
    {
      return _db.Query<Client>(@"
        SELECT
          id,
          nome,
          CPF,
          dataNascimento
        FROM cliente")?.ToArray();
    }

    public Client Get(int id)
    {
      return _db.QueryFirstOrDefault<Client>(@"
        SELECT
          id,
          nome,
          CPF,
          dataNascimento
        FROM cliente
        WHERE id = @Id", new { Id = id });
    }

    public Client Create(Client client)
    {
      int id = _db.QuerySingle<int>(@"
        INSERT INTO cliente 
          (Nome, CPF, dataNascimento)
          VALUES 
          (@Nome, @CPF, @DataNascimento);
        
        SELECT LAST_INSERT_ID();", client);

      client.Id = id;

      return client;
    }

    public Client Update(int id, Client client)
    {
      client.Id = id;

      int affectedRows = _db.Execute(@"
        UPDATE cliente set 
          nome = @Nome,
          CPF = @CPF,
          dataNascimento = @DataNascimento
        WHERE id = @Id", client);

      if (affectedRows == 0) return null;

      return client;
    }

    public void Delete(int id) =>
      _db.Query(@"DELETE FROM cliente WHERE Id = @Id", new { Id = id });
  }
}