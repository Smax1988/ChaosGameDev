using ChaosGameLib.Models;
using System;
using System.Drawing;

namespace ChaosGameLib;

public class ChaosTriangle : ChaosBase
{
    /// <summary>
    /// Draws a point between a random corner point of the triangle and a starting point,
    /// then between that newly added point and another random corner point of the triangle
    /// and repeats the process.
    /// </summary>
    /// <param name="bitmap">the image canvas</param>
    public static Bitmap CreateChaosTriangle(int iterations, Color color)
    {
        Bitmap bitmap = new Bitmap(1000, 800);
        Triangle triangle = CreateTriangle(bitmap, color);
        Coordinates point = triangle.RandomStartingPoint;

        for (int i = 0; i < iterations; i++)
        {
            point = CreateMiddlePoint(GetRandomPoint(triangle), point);
            // Don't add first 100 points to account for some points in the beginning being outside of the triangle
            if (i > 100)
                AddPoint(bitmap, point);
        }
        return bitmap;
    }

    /// <summary>
    ///  Creates the initial equilateral triangle and the first random point
    /// Canvas: Point (0,0) is top left, Point (width, height) is bottom right.
    /// </summary>
    /// <param name="bitmap">This is where the image is created</param>
    /// <returns>The Created Triangle with all of its Points and the random generated starting point</returns>
    private static Triangle CreateTriangle(Bitmap bitmap, Color color)
    {
        int bitmapWidth = bitmap.Width;
        int bitmapHeight = bitmap.Height;
        int marginLeftRight = 100; // Spacing from left and right of the screen;
        int marginBottom = 100; // spacing from bottom
        int triangleLength = bitmapWidth - marginLeftRight * 2; // length of each side of the triangle
        Random random = new Random();

        Coordinates pointA = new Coordinates(marginLeftRight, bitmapHeight - marginBottom, color);
        Coordinates pointB = new Coordinates(bitmapWidth - marginLeftRight, bitmapHeight - marginBottom, color);
        Coordinates pointC = new Coordinates();
        pointC.X = bitmapWidth / 2;
        // Get height of equilateral triangle: Pythagoras
        pointC.Y = bitmapHeight - marginBottom - (int)Math.Sqrt(Math.Pow(triangleLength, 2) - Math.Pow(triangleLength / 2, 2));
        pointC.Color = color;

        Triangle triangle = new Triangle();
        triangle.PointA = pointA;
        triangle.PointB = pointB;
        triangle.PointC = pointC;
        triangle.RandomStartingPoint = new Coordinates(random.Next(0, bitmapWidth), random.Next(0, bitmapHeight), color);

        return triangle;
    }


    /// <summary>
    /// Helper methods that gets a random corner point of the triangle
    /// </summary>
    /// <param name="triangle">The three coordiantes of an equilateral triangle</param>
    /// <returns>A randomly chosen corner point of the triangle</returns>
    private static Coordinates GetRandomPoint(Triangle triangle)
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 4); // min is included, max is excluded
        switch (randomNumber)
        {
            case 1:
                return triangle.PointA;
            case 2:
                return triangle.PointB;
            default:
                return triangle.PointC;
        }
    }
}
