using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRentals.Api.Models.Request
{
  public class RentCommandModel
  {
    [Required]
    public int IdClient { get; set; }

    [Required]
    public int IdMovie { get; set; }
  }
}