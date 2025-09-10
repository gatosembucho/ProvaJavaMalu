using System.ComponentModel.DataAnnotations;

namespace ProvaJavaMalu.UseCases.CreateTrip;

public record CreateTripRequest
{
    [Required]
    [MaxLength(20)]
    public string Title { get; set; }

    [Required]
    [MaxLength(200)]
    [MinLength(40)]
    public string Description { get; set; }

    [Required]
    public int OwnerID { get; set; }
}