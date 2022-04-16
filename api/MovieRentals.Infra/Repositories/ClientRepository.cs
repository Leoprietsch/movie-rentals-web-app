using System.Data;
using Dapper;
using MovieRentals.Domain;
using MovieRentals.Infra.Contracts;

namespace MovieRentals.Infra.Repositories
{
  public class ClientRepository : IClientRepository
  {
    private readonly IDbConnection _db;
    public ClientRepository(IDbConnection db)
    {
      _db = db;
    }
    public Client Create(Client client)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

    public Client Get(int id)
    {
      return _db.QueryFirstOrDefault<Client>(
        @"SELECT 
              id,
              nome,
              CPF,
              dataNascimento
              FROM cliente
              where id = @Id",
         new { Id = id });
    }

    public Client[] GetAll()
    {
      throw new System.NotImplementedException();
    }

    public Client Update(Client client)
    {
      throw new System.NotImplementedException();
    }
  }
}