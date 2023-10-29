namespace ChaosGameLib.Models;

/// <summary>
/// Model for the geometric figure of a square.
/// </summary>
public class Square : Triangle
{
    public Coordinates PointD { get; set; } = new Coordinates();

    /// <summary>
    /// Set coordinates of all corner points of the square. 
    /// Pass Point A, B and C to base class and add Point D to list of all points.
    /// </summary>
    /// <param name="pointA"></param>
    /// <param name="pointB"></param>
    /// <param name="pointC"></param>
    /// <param name="pointD"></param>
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