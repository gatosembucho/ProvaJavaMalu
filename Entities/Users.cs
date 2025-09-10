namespace ProvaJavaMalu.Entities;

public class User
{
    public int ID { get; set; }
    public string NomeCompleto { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    
    public ICollection<Trip> Trips = [];
}