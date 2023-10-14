using System.Drawing;

namespace ChaosGameLib.Models;

public class Triangle: ShapeBase
{
    public Coordinates PointA { get; set; } = new Coordinates ();
    public Coordinates PointB { get; set; } = new Coordinates ();
    public Coordinates PointC { get; set; } = new Coordinates ();
}
