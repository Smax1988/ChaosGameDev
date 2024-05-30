using ChaosGameLib.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace ChaosGameLib;

/// <summary>
/// Base class that provides functionality that all deriving classes have in common.
/// </summary>
public abstract class ChaosBase
{
    protected static readonly Random random = new Random();

    /// <summary>
    /// Adds a Point (pixel) with X and Y Coordinates to a bitmap
    /// </summary>
    /// <param name="bitmap">Bitmap</param>
    /// <param name="point">X and Y Coordinates of the point and the color</param>
    protected static void AddPoint(Bitmap bitmap, Coordinates point)
    {
        // Coordinates need to be greater than 0 and smaller than image size
        if (point.X < 0 || point.Y < 0 || point.X >= bitmap.Width || point.Y >= bitmap.Height)
            throw new ArgumentOutOfRangeException("Coordinates are outside the bounds of the bitmap.");

        bitmap.SetPixel(point.X, point.Y, point.Color);
    }

    /// <summary>
    /// Creates a point that is in the middle of two given points
    /// </summary>
    /// <param name="pointA">Coordinates of one Point</param>
    /// <param name="pointB">Coordinates of another point</param>
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

    /// <summary>
    /// Selects a random corner point of a given shape by generating a random index to
    /// get an item from the List AllPoints
    /// </summary>
    /// <param name="shape">Either a Triangle, a Square, a Pentagon or a Hexagon</param>
    /// <returns>Coordnates of the randomly selected corner point</returns>
    protected static Coordinates GetRandomCornerPoint(ShapeBase shape)
    {
        if (shape.AllPoints.Count > 0)
        {
            int randomIndex = random.Next(0, shape.AllPoints.Count); // min included, max excluded
            return shape.AllPoints[randomIndex];
        }
        throw new InvalidOperationException("The list of coordinates is empty. Cannot get a random element.");
    }

    /// <summary>
    /// Creates a MemoryStream from a bitmap with ImageFormat png
    /// </summary>
    /// <param name="image">The bitmap that needs to be converted into a png MemoryStream</param>
    /// <returns>The png MemoryStream</returns>
    protected static MemoryStream CreateImageStream(Bitmap image)
    {
        MemoryStream memoryStream = new MemoryStream();
        image.Save(memoryStream, ImageFormat.Png);
        memoryStream.Position = 0;
        return memoryStream;
    }
}
