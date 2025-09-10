namespace ProvaJavaMalu.Entities;

public class Trip
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int IDUser { get; set; }
     public ICollection<User> Users = [];
    public ICollection<Point> Points = [];
}