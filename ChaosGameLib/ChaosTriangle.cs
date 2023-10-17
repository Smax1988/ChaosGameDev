using ChaosGameLib.Models;
using System;
using System.Drawing;

namespace ChaosGameLib;

public class ChaosTriangle : ChaosBase
{

    public static Bitmap CreateTriangleBitmap(int iterations, int imgWidth, int imgHeight, Color color)
    {
        Bitmap bitmap = new Bitmap(imgWidth, imgHeight);
        Triangle triangle = CreateTriangle(bitmap, color);
        Coordinates point = triangle.RandomStartingPoint;

        for (int i = 0; i < iterations; i++)
        {
            Coordinates randomCornerPoint = GetRandomCornerPoint(triangle);
            point = CreateMiddlePoint(randomCornerPoint, point);
            // Don't add first 100 points to account for some points in the beginning being outside of the triangle
            if (i > 100)
                AddPoint(bitmap, point);
        }
        return bitmap;
    }


    private static Triangle CreateTriangle(Bitmap bitmap, Color color)
    {
        int bitmapWidth = bitmap.Width;
        int bitmapHeight = bitmap.Height;
        int marginLeftRight = 100; // Spacing from left and right of the screen;
        int marginBottom = 100; // spacing from bottom
        int triangleLength = bitmapWidth - marginLeftRight * 2; // length of each side of the triangle

        Coordinates pointA = new Coordinates(marginLeftRight, bitmapHeight - marginBottom, color);
        Coordinates pointB = new Coordinates(bitmapWidth - marginLeftRight, bitmapHeight - marginBottom, color);
        Coordinates pointC = new Coordinates();
        pointC.X = bitmapWidth / 2;
        // Get height of equilateral triangle: Pythagoras
        pointC.Y = bitmapHeight - marginBottom - (int)Math.Sqrt(Math.Pow(triangleLength, 2) - Math.Pow(triangleLength / 2, 2));
        pointC.Color = color;

        Triangle triangle = new Triangle(pointA, pointB, pointC);
        triangle.RandomStartingPoint = new Coordinates(random.Next(0, bitmapWidth), random.Next(0, bitmapHeight), color);

        return triangle;
    }
}
