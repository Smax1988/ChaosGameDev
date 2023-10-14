using ChaosGameLib.Models;
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
    /// Creates a point that is in the middle of two given points
    /// </summary>
    /// <param name="poinA">One Point</param>
    /// <param name="pointB">Another point</param>
    /// <returns>The point in the middle</returns>
    protected static Coordinates CreateMiddlePoint(Coordinates poinA, Coordinates pointB)
    {
        return new Coordinates
        {
            X = (poinA.X + pointB.X) / 2,
            Y = (poinA.Y + pointB.Y) / 2,
            Color = Brushes.Red
        };
    }
}
