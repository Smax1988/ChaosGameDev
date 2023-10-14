using ChaosGameLib.Models;
using System;
using System.Windows.Controls;

namespace ChaosGameLib;

public class ChaosSquare : ChaosBase
{
    public static Square CreateSquare(Canvas canvas)
    {
        int canvasWidth = (int)canvas.ActualWidth;
        int canvasHeight = (int)canvas.ActualHeight;
        int sideLength = canvasWidth - 200; // Spacing of 100 from left and right of the screen;
        Random random = new Random();

        // Bottom left corner point A
        Coordinates pointA = new Coordinates();
        pointA.X = 100;
        pointA.Y = canvasHeight - 100;

        // Bottom right corner point B
        Coordinates pointB = new Coordinates();
        pointB.X = canvasWidth - 100;
        pointB.Y = canvasHeight - 100;

        // Top right corner point C
        Coordinates pointC = new Coordinates();
        pointC.X = canvasWidth -100;
        pointC.Y = (canvasHeight - sideLength);

        // Top left corner point D
        Coordinates pointD = new Coordinates();
        pointD.X = 100;
        pointD.Y = (canvasHeight - sideLength);

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

    public static void CreateChaosSquare(Canvas canvas)
    {
        throw new NotImplementedException();
    }
}
