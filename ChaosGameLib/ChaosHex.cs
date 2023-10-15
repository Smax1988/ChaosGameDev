using ChaosGameLib.Models;
using System;
using System.Drawing;

namespace ChaosGameLib;

public class ChaosHex : ChaosBase
{
    public static Bitmap CreateChaosHex(int iterations, Color color)
    {
        Bitmap bitmap = new Bitmap(1000, 800);

        Coordinates LastCornerPoint = new Coordinates();
        Hexagon hexaxon = CreateHexagon(bitmap, color);
        Coordinates point = hexaxon.RandomStartingPoint;

        for (int i = 0; i < iterations; i++)
        {
            Coordinates randomCornerPoint = GetRandomPoint(hexaxon);
            if (randomCornerPoint != LastCornerPoint)
            {
                point = CreateMiddlePoint(randomCornerPoint, point);
                LastCornerPoint = randomCornerPoint;

                if (i > 100)
                    AddPoint(bitmap, point);
            }
        }
        return bitmap;
    }

    private static Hexagon CreateHexagon(Bitmap bitmap, Color color)
    {
        int bitmapWidth = bitmap.Width;
        int bitmapHeight = bitmap.Height;
        int centerLeftRight = bitmapWidth / 2; // Center of the bitmap horizontally
        int centerTopBottom = bitmapHeight / 2 - 50; // Center of the bitmap vertically
        int sideLength = 400;
        Random random = new Random();

        // Calculate the corner points of the hexagon
        Coordinates pointA = new Coordinates(centerLeftRight, centerTopBottom - sideLength, color);
        Coordinates pointB = new Coordinates(centerLeftRight + (int)(sideLength * Math.Sqrt(3) / 2), centerTopBottom - sideLength / 2, color);
        Coordinates pointC = new Coordinates(centerLeftRight + (int)(sideLength * Math.Sqrt(3) / 2), centerTopBottom + sideLength / 2, color);
        Coordinates pointD = new Coordinates(centerLeftRight, centerTopBottom + sideLength, color);
        Coordinates pointE = new Coordinates(centerLeftRight - (int)(sideLength * Math.Sqrt(3) / 2), centerTopBottom + sideLength / 2, color);
        Coordinates pointF = new Coordinates(centerLeftRight - (int)(sideLength * Math.Sqrt(3) / 2), centerTopBottom - sideLength / 2, color);
        // Random Starting Point

        Hexagon hexagon = new Hexagon();
        hexagon.PointA = pointA;
        hexagon.PointB = pointB;
        hexagon.PointC = pointC;
        hexagon.PointD = pointD;
        hexagon.PointE = pointE;
        hexagon.PointF = pointF;
        hexagon.RandomStartingPoint = new Coordinates(random.Next(0, bitmapWidth), random.Next(0, bitmapHeight));

        return hexagon;
    }

    private static Coordinates GetRandomPoint(Hexagon hexagon)
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 7); // min is included, max is excluded
        switch (randomNumber)
        {
            case 1:
                return hexagon.PointA;
            case 2:
                return hexagon.PointB;
            case 3:
                return hexagon.PointC;
            case 4:
                return hexagon.PointD;
            case 5:
                return hexagon.PointE;
            default:
                return hexagon.PointF;
        }
    }
}
