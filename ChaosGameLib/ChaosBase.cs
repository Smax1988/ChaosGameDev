using ChaosGameLib.Models;
using System;
using System.Drawing;

namespace ChaosGameLib;

public abstract class ChaosBase
{
    /// <summary>
    /// Adds a Point with X and Y Coordinates to a canvas
    /// </summary>
    /// <param name="canvas">WPF Canvas</param>
    /// <param name="coordinates">X and Y Coordinates of the point and the color</param>
    // Define a function to add a point to a bitmap
    protected static void AddPoint(Bitmap bitmap, Coordinates point)
    {
        // Make sure the coordinates are within the bounds of the bitmap
        if (point.X < 0 || point.Y < 0 || point.X >= bitmap.Width || point.Y >= bitmap.Height)
        {
            throw new ArgumentOutOfRangeException("Coordinates are outside the bounds of the bitmap.");
        }

        // Set the color of the pixel at the specified coordinates
        bitmap.SetPixel(point.X, point.Y, point.Color);
    }

    /// <summary>
    /// Creates a point that is in the middle of two given points
    /// </summary>
    /// <param name="pointA">One Point</param>
    /// <param name="pointB">Another point</param>
    /// <returns>The point in the middle</returns>
    protected static Coordinates CreateMiddlePoint(Coordinates pointA, Coordinates pointB)
    {
        return new Coordinates
        {
            X = (pointA.X + pointB.X) / 2,
            Y = (pointA.Y + pointB.Y) / 2,
            Color = pointA.Color
        };
    }
}
