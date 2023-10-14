using ChaosGameLib.Models;
using System;
using System.Drawing;

namespace ChaosGameLib;

public class ChaosSquare : ChaosBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="iterations"></param>
    /// <returns></returns>
    public static Bitmap CreateChaosSquare(int iterations, Color color)
    {
        Bitmap bitmap = new Bitmap(1000, 800);
        Coordinates LastCornerPoint = new Coordinates();
        Square square = CreateSquare(bitmap, color);
        Coordinates point = square.RandomStartingPoint;

        for (int i = 0; i < iterations; i++)
        {
            Coordinates randomCornerPoint = GetRandomPoint(square);
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bitmap"></param>
    /// <returns></returns>
    private static Square CreateSquare(Bitmap bitmap, Color color)
    {
        int bitmapWidth = bitmap.Width;
        int bitmapHeight = bitmap.Height;
        int marginLeftRight = 150; // Spacing from left and right of the screen;
        int marginBottom = 95; // spacing from bottom
        int sideLength = bitmapWidth - marginLeftRight * 2; // Spacing of 100 from left and right of the screen;
        Random random = new Random();

        Coordinates pointA = new Coordinates(marginLeftRight, bitmapHeight - marginBottom, color);
        Coordinates pointB = new Coordinates(bitmapWidth - marginLeftRight, bitmapHeight - marginBottom, color);
        Coordinates pointD = new Coordinates(marginLeftRight, bitmapHeight - marginBottom - sideLength, color);
        Coordinates pointC = new Coordinates(marginLeftRight + sideLength, bitmapHeight - marginBottom - sideLength, color);

        // Create square and fill with corner points and random starting point
        Square square = new Square();
        square.PointA = pointA;
        square.PointB = pointB;
        square.PointC = pointC;
        square.PointD = pointD;
        square.RandomStartingPoint = new Coordinates(random.Next(0, bitmapWidth), random.Next(0, bitmapHeight), color);

        return square;
    }

    /// <summary>
    /// Helper methods that gets a random corner point of the square
    /// </summary>
    /// <param name="square">The three coordiantes of square</param>
    /// <returns>A randomly chosen corner point of the square</returns>
    protected static Coordinates GetRandomPoint(Square square)
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 5); // min is included, max is excluded
        switch (randomNumber)
        {
            case 1:
                return square.PointA;
            case 2:
                return square.PointB;
            case 3:
                return square.PointC;
            default:
                return square.PointD;
        }
    }
}
