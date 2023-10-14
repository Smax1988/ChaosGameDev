using ChaosGameLib.Models;
using System;
using System.Windows.Controls;

namespace ChaosGameLib;

public class ChaosSquare : ChaosBase
{
    private static Square CreateSquare(Canvas canvas)
    {
        int canvasWidth = (int)canvas.ActualWidth;
        int canvasHeight = (int)canvas.ActualHeight;
        int marginLeftRight = 150; // Spacing from left and right of the screen;
        int marginBottom = 50; // spacing from bottom
        int sideLength = canvasWidth - marginLeftRight * 2; // Spacing of 100 from left and right of the screen;
        Random random = new Random();

        // Bottom left corner point A
        Coordinates pointA = new Coordinates();
        pointA.X = marginLeftRight;
        pointA.Y = canvasHeight - marginBottom;

        // Bottom right corner point B
        Coordinates pointB = new Coordinates();
        pointB.X = canvasWidth - marginLeftRight;
        pointB.Y = canvasHeight - marginBottom;

        // Top right corner point C
        Coordinates pointD = new Coordinates();
        pointD.X = marginLeftRight;
        pointD.Y = canvasHeight - marginBottom - sideLength;

        // Top left corner point D
        Coordinates pointC = new Coordinates();
        pointC.X = marginLeftRight + sideLength;
        pointC.Y = canvasHeight - marginBottom - sideLength;

        // Random Starting Point
        Coordinates randomStartingPoint = new Coordinates();
        randomStartingPoint.X = random.Next(0, canvasWidth);
        randomStartingPoint.Y = random.Next(0, canvasHeight);

        AddPoint(canvas, pointA);
        AddPoint(canvas, pointB);
        AddPoint(canvas, pointC);
        AddPoint(canvas, pointD);

        // Create square and fill with corner points and random starting point
        Square square = new Square();
        square.PointA = pointA;
        square.PointB = pointB;
        square.PointC = pointC;
        square.PointD = pointD;
        square.RandomStartingPoint = randomStartingPoint;

        return square;
    }

    public static void CreateChaosSquare(Canvas canvas, int iterations)
    {
        Coordinates LastCornerPoint = new Coordinates();
        Square square = CreateSquare(canvas);
        Coordinates point = square.RandomStartingPoint;

        for (int i = 0; i < iterations; i++)
        {
            Coordinates randomCornerPoint = GetRandomPoint(square);
            if (randomCornerPoint != LastCornerPoint)
            {
                point = CreateMiddlePoint(randomCornerPoint, point);
                LastCornerPoint = randomCornerPoint;

                if (i > 100)
                    AddPoint(canvas, point);
            }
        }
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
