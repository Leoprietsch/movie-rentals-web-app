using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRentals.Api.Models.Request
{
  public class ClientCommandModel
  {
    [Required]
    [MaxLength(200, ErrorMessage = "O tamanho máximo do nome são 200 caracteres")]
    public string Nome { get; set; }

    [Required]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF pode conter apenas 11 caracteres numéricos")]
    public string CPF { get; set; }

    [Required]
    public Nullable<DateTime> DataNascimento { get; set; }
  }
}