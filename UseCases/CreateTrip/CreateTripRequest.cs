using System.ComponentModel.DataAnnotations;

namespace ProvaJavaMalu.UseCases.CreateTrip;

public record CreateTripRequest
{
    [Required]
    [MaxLength(20)]
    public string Title { get; init; }

    [Required]
    [MaxLength(200)]
    [MinLength(40)]
    public string Description { get; init; }

    [Required]
    public int OwnerID { get; init; }
}