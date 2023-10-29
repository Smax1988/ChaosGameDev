using System.Drawing;

namespace ChaosGameLib.Models;

/// <summary>
/// Contains x and y coordinates of a point and its color.
/// </summary>
public class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }
    public Color Color { get; set; } = Color.Cyan;

    public Coordinates() {}

    /// <summary>
    /// Set x and y coordinates of a point.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Set x and y coordinates and the color of a point.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="color"></param>
    public Coordinates(int x, int y, Color color)
    {
        X = x;
        Y = y;
        Color = color;
    }
}
