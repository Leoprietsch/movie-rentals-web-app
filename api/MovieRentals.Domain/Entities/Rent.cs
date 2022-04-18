using System;

namespace MovieRentals.Domain
{
  public class Rent
  {
    public int Id { get; set; }
    public Client Cliente { get; set; }
    public Movie Filme { get; set; }
    public DateTime DataLocacao { get; set; }
    public DateTime? DataDevolucao { get; set; }

    public Rent() { }

    public Rent(Client cliente, Movie filme)
    {
      Cliente = cliente;
      Filme = filme;
      DataLocacao = DateTime.Now;
    }
  }
}
