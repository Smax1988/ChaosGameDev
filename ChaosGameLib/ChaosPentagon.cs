using ChaosGameLib.Models;
using System;
using System.Drawing;

namespace ChaosGameLib;

public class ChaosPentagon : ChaosBase
{
    public static Bitmap CreateChaosPentagon(int iterations, Color color)
    {
        Bitmap bitmap = new Bitmap(1000, 800);

        Coordinates LastCornerPoint = new Coordinates();
        Pentagon pentagon = CreatePentagon(bitmap, color);
        Coordinates point = pentagon.RandomStartingPoint;

        for (int i = 0; i < iterations; i++)
        {
            Coordinates randomCornerPoint = GetRandomCornerPoint(pentagon);
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

    public static Pentagon CreatePentagon(Bitmap bitmap, Color color)
    {
        int bitmapWidth = bitmap.Width;
        int bitmapHeight = bitmap.Height;
        int centerLeftRight = bitmapWidth / 2; // Center of the bitmap horizontally
        int centerTopBottom = bitmapHeight / 2 - 50; // Center of the bitmap vertically
        int sideLength = 420;

        double angleIncrement = 2 * Math.PI / 5;
        double startAngle = Math.PI / 2;
        Coordinates[] coordinates = new Coordinates[5];

        for (int i = 0; i < 5; i++)
        {
            double angle = startAngle + i * angleIncrement;
            int x = centerLeftRight + (int)(sideLength * Math.Cos(angle));
            int y = centerTopBottom - (int)(sideLength * Math.Sin(angle));
            coordinates[i] = new Coordinates(x, y, color);
        }

        Pentagon pentagon = new Pentagon(coordinates[0], coordinates[1], coordinates[2], coordinates[3], coordinates[4]);
        pentagon.RandomStartingPoint = new Coordinates(random.Next(0, bitmapWidth), random.Next(0, bitmapHeight));

        return pentagon;
    }

    private static Coordinates GetRandomPoint(Pentagon pentagon)
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 6); // min is included, max is excluded
        switch (randomNumber)
        {
            case 1:
                return pentagon.PointA;
            case 2:
                return pentagon.PointB;
            case 3:
                return pentagon.PointC;
            case 4:
                return pentagon.PointD;
            default:
                return pentagon.PointE;
        }
    }
}
