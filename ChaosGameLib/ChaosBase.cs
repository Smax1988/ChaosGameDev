using ChaosGameLib.Models;
using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ChaosGameLib;

public abstract class ChaosBase
{
    /// <summary>
    /// Adds a Point with X and Y Coordinates to a canvas
    /// </summary>
    /// <param name="canvas">WPF Canvas</param>
    /// <param name="coordinates">X and Y Coordinates of the point and the color</param>
    protected static void AddPoint(Canvas canvas, Coordinates coordinates)
    {
        Ellipse newPoint = new Ellipse
        {
            Width = 1,
            Height = 1,
            Fill = coordinates.Color
        };

        Canvas.SetLeft(newPoint, coordinates.X);
        Canvas.SetTop(newPoint, coordinates.Y);

        canvas.Children.Add(newPoint);
    }


    /// <summary>
    /// Helper methods that gets a random corner point of the triangle
    /// </summary>
    /// <param name="triangle">The three coordiantes of an equilateral triangle</param>
    /// <returns>A randomly chosen corner point of the triangle</returns>
    protected static Coordinates GetRandomPoint(Triangle triangle)
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 4); // min is included, max is excluded
        switch (randomNumber)
        {
            case 1:
                return triangle.PointA;
            case 2:
                return triangle.PointB;
            default:
                return triangle.PointC;
        }
    }

    /// <summary>
    /// Creates a point that is in the middle of a triangle corner point and a given point
    /// </summary>
    /// <param name="trianglePoint">A corner point of the triangle</param>
    /// <param name="point">Another point</param>
    /// <param name="useRandomColors">Option to change color of a point to a random color. Defauol is false</param>
    /// <returns>The point in the middle</returns>
    protected static Coordinates CreateMiddlePoint(Coordinates trianglePoint, Coordinates point, bool useRandomColors = false)
    {
        SolidColorBrush color = Brushes.Red;

        if (useRandomColors)
        {
            Random random = new Random();
            PropertyInfo[] properties = typeof(Brushes).GetProperties();
            color = (SolidColorBrush)properties[random.Next(properties.Length)].GetValue(null, null)!;
        }

        return new Coordinates
        {
            X = (trianglePoint.X + point.X) / 2,
            Y = (trianglePoint.Y + point.Y) / 2,
            Color = color
        };
    }
}
