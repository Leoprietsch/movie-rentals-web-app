using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRentals.Api.Models.Request
{
  public class MovieCommandModel
  {
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "O tamanho máximo do título são 100 caracteres")]
    public string Titulo { get; set; }

    [Required]
    public int ClassificacaoIndicativa { get; set; }

    [Required]
    public bool Lancamento { get; set; }
  }
}