using ChaosGameLib.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace ChaosGameLib;

public abstract class ChaosBase
{
    protected static readonly Random random = new Random();

    /// <summary>
    /// Adds a Point with X and Y Coordinates to a canvas
    /// </summary>
    /// <param name="bitmap"></param>
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

    protected static Coordinates GetRandomCornerPoint(ShapeBase shape)
    {
        if (shape.AllPoints.Count > 0)
        {
            int randomIndex = random.Next(0, shape.AllPoints.Count); // min included, max excluded
            return shape.AllPoints[randomIndex];
        }
        throw new InvalidOperationException("The list of coordinates is empty. Cannot get a random element.");
    }

    protected static BitmapImage CreateBitmapImage(Bitmap image)
    {
        using MemoryStream memory = new MemoryStream();
        image.Save(memory, ImageFormat.Bmp);
        memory.Position = 0;
        BitmapImage bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = memory;
        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        bitmapImage.EndInit();

        return bitmapImage;
    }
}
