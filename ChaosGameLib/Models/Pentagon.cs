namespace ChaosGameLib.Models;

/// <summary>
/// Model for the geometric figure of a pentagon.
/// </summary>
public class Pentagon : Square
{
    public Coordinates PointE { get; set; } = new Coordinates();

    /// <summary>
    /// Set coordinates of all corner points of the pentagon.
    /// Pass Point A, B, C and D to base class and add point E to list of all points.
    /// </summary>
    /// <param name="pointA"></param>
    /// <param name="pointB"></param>
    /// <param name="pointC"></param>
    /// <param name="pointD"></param>
    /// <param name="pointE"></param>
    public Pentagon(Coordinates pointA, 
                    Coordinates pointB, 
                    Coordinates pointC, 
                    Coordinates pointD, 
                    Coordinates pointE) 
                    : base(pointA, pointB, pointC, pointD)
    {
        PointE = pointE;
        AllPoints.Add(pointE);
    }
}
