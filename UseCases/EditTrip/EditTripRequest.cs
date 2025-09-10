namespace ProvaJavaMalu.UseCases.EditTrip;

public record EditTripRequest
{
    public int OwnerID { get; init; }
    public int TripID { get; init; }
    public int PointID { get; init; }
}