namespace ChaosGameLib.Models;

public class Square : Triangle
{
    public Coordinates PointD { get; set; } = new Coordinates();

    public Square(Coordinates pointA, 
                  Coordinates pointB, 
                  Coordinates pointC, 
                  Coordinates pointD) 
                  : base(pointA, pointB, pointC)
    {
        PointD = pointD;
        AllPoints.Add(pointD);
    }
}