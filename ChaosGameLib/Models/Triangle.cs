namespace ChaosGameLib.Models;

public class Triangle
{
    public Coordinates PointA { get; set; } = new Coordinates { X = 0, Y = 0 };
    public Coordinates PointB { get; set; } = new Coordinates { X = 0, Y = 0 };
    public Coordinates PointC { get; set; } = new Coordinates { X = 0, Y = 0 };
    public Coordinates RandomStartingPoint { get; set; } = new Coordinates { X = 0, Y = 0 };
}
