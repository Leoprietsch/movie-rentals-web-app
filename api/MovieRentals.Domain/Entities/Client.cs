using System;

namespace MovieRentals.Domain
{
  public class Client
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
  }
}
