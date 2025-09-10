namespace ProvaJavaMalu.Entities;

public class Point
{
    public int ID { get; set; }
    public string Title { get; set; }
    
    public int IDTrip { get; set; }
    public Trip Place { get; set; }
}