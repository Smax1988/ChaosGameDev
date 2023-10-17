namespace ChaosGameLib.Models;

public class Hexagon : Pentagon
{
    public Coordinates PointF { get; set; } = new Coordinates();

    public Hexagon(Coordinates pointA,
                   Coordinates pointB,
                   Coordinates pointC,
                   Coordinates pointD,
                   Coordinates pointE,
                   Coordinates pointF)
                   : base(pointA, pointB, pointC, pointD, pointE)
    {
        PointE = pointF;
        AllPoints.Add(pointF);
    }
}
