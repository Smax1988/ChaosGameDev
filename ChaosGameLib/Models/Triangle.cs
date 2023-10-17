using System.Collections.Generic;
using System.Windows.Documents;

namespace ChaosGameLib.Models;

public class Triangle: ShapeBase
{
    public Coordinates PointA { get; set; } = new Coordinates ();
    public Coordinates PointB { get; set; } = new Coordinates ();
    public Coordinates PointC { get; set; } = new Coordinates ();

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
