namespace MovieRentals.Domain
{
  public class Movie
  {
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int ClassificacaoIndicativa { get; set; }
    public bool Lancamento { get; set; }

    public Movie() { }
    public Movie(int id, string titulo, int classificacaoIndicativa, bool lancamento)
    {
      Id = id;
      Titulo = titulo;
      ClassificacaoIndicativa = classificacaoIndicativa;
      Lancamento = lancamento;
    }
  }
}
