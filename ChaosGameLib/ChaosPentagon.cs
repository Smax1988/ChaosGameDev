using ChaosGameLib.Models;
using System;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace ChaosGameLib;

public class ChaosPentagon : ChaosBase
{
    public static BitmapImage CreatePentagonBitmap(int iterations, int imgWidth, int imgHeight, Color color)
    {
        Bitmap bitmap = new Bitmap(imgWidth, imgHeight);

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
        return CreateBitmapImage(bitmap);
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
}
