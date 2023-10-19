using ChaosGameLib.Models;
using System;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace ChaosGameLib;

public class ChaosSquare : ChaosBase
{
    public static BitmapImage CreateSquareBitmap(int iterations, int imgWidth, int imgHeight, Color color)
    {
        Bitmap bitmap = new Bitmap(imgWidth, imgHeight);
        Coordinates LastCornerPoint = new Coordinates();
        Square square = CreateSquare(imgWidth, imgHeight, color);
        Coordinates point = square.RandomStartingPoint;

        for (int i = 0; i < iterations; i++)
        {
            Coordinates randomCornerPoint = GetRandomCornerPoint(square);
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


    private static Square CreateSquare(int width, int height, Color color)
    {
        int bitmapWidth = width;
        int bitmapHeight = height;
        int marginLeftRight = 150; // Spacing from left and right of the screen;
        int marginBottom = 95; // spacing from bottom
        int sideLength = bitmapWidth - marginLeftRight * 2; // Spacing of 100 from left and right of the screen;

        Coordinates pointA = new Coordinates(marginLeftRight, bitmapHeight - marginBottom, color);
        Coordinates pointB = new Coordinates(bitmapWidth - marginLeftRight, bitmapHeight - marginBottom, color);
        Coordinates pointD = new Coordinates(marginLeftRight, bitmapHeight - marginBottom - sideLength, color);
        Coordinates pointC = new Coordinates(marginLeftRight + sideLength, bitmapHeight - marginBottom - sideLength, color);

        // Create square and fill with corner points and random starting point
        Square square = new Square(pointA, pointB, pointC, pointD);
        square.RandomStartingPoint = new Coordinates(random.Next(0, bitmapWidth), random.Next(0, bitmapHeight), color);

        return square;
    }
}
