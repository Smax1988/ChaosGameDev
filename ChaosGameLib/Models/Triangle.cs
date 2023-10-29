using System.Collections.Generic;
using System.Windows.Documents;

namespace ChaosGameLib.Models;

/// <summary>
/// Model for the geometric figure of a triangle.
/// </summary>
public class Triangle: ShapeBase
{
    public Coordinates PointA { get; set; } = new Coordinates ();
    public Coordinates PointB { get; set; } = new Coordinates ();
    public Coordinates PointC { get; set; } = new Coordinates ();

    /// <summary>
    /// Set the coordinates of all corner points of the triangle and add it to list of all points.
    /// </summary>
    /// <param name="pointA">Point A</param>
    /// <param name="pointB">Point B</param>
    /// <param name="pointC">Point C</param>
    public Triangle(Coordinates pointA, 
                    Coordinates pointB, 
                    Coordinates pointC)
    {
        PointA = pointA;
        PointB = pointB;
        PointC = pointC;

        AllPoints.Add(pointA);
        AllPoints.Add(pointB);
        AllPoints.Add(pointC);
    }
}
