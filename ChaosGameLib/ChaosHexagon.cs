using ChaosGameLib.Models;
using System;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace ChaosGameLib;

/// <summary>
/// Class provides functionality to create a hexagon fractal.
/// </summary>
public class ChaosHexagon : ChaosBase
{
    /// <summary>
    /// Creates the fractal based on a hexagon as a BitmapImage
    /// </summary>
    /// <param name="iterations">Number of points added to the bitmap</param>
    /// <param name="imgWidth">Widht of BitmapImage</param>
    /// <param name="imgHeight">Height of BitmapImage</param>
    /// <param name="color">Color of the points</param>
    /// <returns>Fractal based on a hexagon as BitmapImage</returns>
    public static BitmapImage CreateHexagonBitmap(int iterations, int imgWidth, int imgHeight, Color color)
    {
        Bitmap bitmap = new Bitmap(imgWidth, imgHeight);
        Coordinates LastCornerPoint = new Coordinates();
        Hexagon hexaxon = CreateHexagon(imgWidth, imgHeight, color);
        Coordinates point = hexaxon.RandomStartingPoint;

        for (int i = 0; i < iterations; i++)
        {
            Coordinates randomCornerPoint = GetRandomCornerPoint(hexaxon);
            if (randomCornerPoint != LastCornerPoint)
            {
                point = CreateMiddlePoint(randomCornerPoint, point);
                LastCornerPoint = randomCornerPoint;

                if (i > 100)
                    AddPoint(bitmap, point);
            }
        }
        return CreateBitmapImage(bitmap);
    }

    /// <summary>
    /// Calculates the six corner points of the hexagon and the random starting point
    /// </summary>
    /// <param name="width">Widht of the bitmap where the fractal will be drawn</param>
    /// <param name="height">Height of the bitmap where the fractal will be drawn</param>
    /// <param name="color">Color for the random starting point</param>
    /// <returns>A hexagon with all its corner points and the random starting point</returns>
    private static Hexagon CreateHexagon(int width, int height, Color color)
    {
        int bitmapWidth = width;
        int bitmapHeight = height;
        int centerLeftRight = bitmapWidth / 2; // Center of the bitmap horizontally
        int centerTopBottom = bitmapHeight / 2 - 50; // Center of the bitmap vertically
        int sideLength = 400;

        // Calculate the corner points of the hexagon
        Coordinates pointA = new Coordinates(centerLeftRight, centerTopBottom - sideLength, color);
        Coordinates pointB = new Coordinates(centerLeftRight + (int)(sideLength * Math.Sqrt(3) / 2), centerTopBottom - sideLength / 2, color);
        Coordinates pointC = new Coordinates(centerLeftRight + (int)(sideLength * Math.Sqrt(3) / 2), centerTopBottom + sideLength / 2, color);
        Coordinates pointD = new Coordinates(centerLeftRight, centerTopBottom + sideLength, color);
        Coordinates pointE = new Coordinates(centerLeftRight - (int)(sideLength * Math.Sqrt(3) / 2), centerTopBottom + sideLength / 2, color);
        Coordinates pointF = new Coordinates(centerLeftRight - (int)(sideLength * Math.Sqrt(3) / 2), centerTopBottom - sideLength / 2, color);

        Hexagon hexagon = new Hexagon(pointA, pointB, pointC, pointD, pointE, pointF);
        hexagon.RandomStartingPoint = new Coordinates(random.Next(0, bitmapWidth), random.Next(0, bitmapHeight));

        return hexagon;
    }
}
