namespace ChaosGameLib.Models;

public class Triangle
{
    public Coordinates RandomStartingPoint { get; set; } = new Coordinates();
    public Coordinates PointA { get; set; } = new Coordinates ();
    public Coordinates PointB { get; set; } = new Coordinates ();
    public Coordinates PointC { get; set; } = new Coordinates ();
}
