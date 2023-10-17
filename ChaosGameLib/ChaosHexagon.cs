using ChaosGameLib.Models;
using System;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace ChaosGameLib;

public class ChaosHexagon : ChaosBase
{
    public static BitmapImage CreateHexBitmap(int iterations, int imgWidth, int imgHeight, Color color)
    {
        Bitmap bitmap = new Bitmap(imgWidth, imgHeight);
        Coordinates LastCornerPoint = new Coordinates();
        Hexagon hexaxon = CreateHexagon(bitmap, color);
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

    private static Hexagon CreateHexagon(Bitmap bitmap, Color color)
    {
        int bitmapWidth = bitmap.Width;
        int bitmapHeight = bitmap.Height;
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
