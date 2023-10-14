namespace ChaosGameLib.Models;

public class Hexagon : Square
{
    public Coordinates PointE { get; set; } = new Coordinates();
    public Coordinates PointF { get; set; } = new Coordinates();
}
