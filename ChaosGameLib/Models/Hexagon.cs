namespace ChaosGameLib.Models;

/// <summary>
/// Model for the geometric figure of a hexagon.
/// </summary>
public class Hexagon : Pentagon
{
    public Coordinates PointF { get; set; } = new Coordinates();

    /// <summary>
    /// Set coordinates of all corner points of the hexagon.
    /// Pass Points A, B, C, D and E to base class and add point F to list of all points.
    /// </summary>
    /// <param name="pointA"></param>
    /// <param name="pointB"></param>
    /// <param name="pointC"></param>
    /// <param name="pointD"></param>
    /// <param name="pointE"></param>
    /// <param name="pointF"></param>
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
