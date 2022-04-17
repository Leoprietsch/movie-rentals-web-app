using MovieRentals.Domain;
using MovieRentals.Infra.Contracts;
using MovieRentals.Service.Contracts;

namespace MovieRentals.Service.Services
{
  public class RentService : IRentService
  {
    private readonly IRentRepository _rentRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IMovieRepository _movieRepository;

    public RentService(IRentRepository rentRepository, IClientRepository clientRepository, IMovieRepository movieRepository)
    {
      _rentRepository = rentRepository;
      _clientRepository = clientRepository;
      _movieRepository = movieRepository;
    }

    public Rent[] GetAll()
    {
      return _rentRepository.GetAll();
    }

    public Rent Get(int id)
    {
      return _rentRepository.Get(id);
    }

    public Rent Create(int idClient, int idMovie)
    {
      Client client = _clientRepository.Get(idClient);
      Movie movie = _movieRepository.Get(idMovie);

      Rent rent = new Rent(client, movie);

      return _rentRepository.Create(rent);
    }

    public Rent Update(int id, int idClient, int idMovie)
    {
      Rent rent = _rentRepository.Get(id);
      Client client = _clientRepository.Get(idClient);
      Movie movie = _movieRepository.Get(idMovie);

      rent.Cliente = client;
      rent.Filme = movie;

      return _rentRepository.Update(rent);
    }

    public void Delete(int id)
    {
      _rentRepository.Delete(id);
    }

    public Rent Return(int id)
    {
      return _rentRepository.Return(id);

    }
  }
}