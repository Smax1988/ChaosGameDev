using ChaosGameLib.Models;
using System;
using System.Windows.Controls;

namespace ChaosGameLib;

public class ChaosTriangle : ChaosBase
{
    /// <summary>
    ///  Creates the initial equilateral triangle and the first random point
    /// Canvas: Point (0,0) is top left, Point (width, height) is bottom right.
    /// </summary>
    /// <param name="canvas">WPF Canvas Control. This is where the magic happens</param>
    /// <returns>The Created Triangle with all of its Points and the random generated starting point</returns>
    public static Triangle CreateTriangle(Canvas canvas)
    {
        int canvasWidth = (int)canvas.ActualWidth;
        int canvasHeight = (int)canvas.ActualHeight;
        int triangleLength = canvasWidth - 200; // Spacing of 50 from left and right of the screen;
        Random random = new Random();

        // Left corner point A
        Coordinates pointA = new Coordinates();
        pointA.X = 100;
        pointA.Y = canvasHeight - 100;

        // Right corner point B
        Coordinates pointB = new Coordinates();
        pointB.X = canvasWidth - 100;
        pointB.Y = canvasHeight - 100;

        // Top corner point C
        Coordinates pointC = new Coordinates();
        pointC.X = canvasWidth / 2;
        // Get height of equilateral triangle: Pythagoras
        pointC.Y = canvasHeight - (int)Math.Sqrt(Math.Pow(triangleLength, 2) - Math.Pow(triangleLength / 2, 2));

        // Random Starting Point
        Coordinates randomStartingPoint = new Coordinates();
        randomStartingPoint.X = random.Next(0, canvasWidth);
        randomStartingPoint.Y = random.Next(0, canvasHeight);

        AddPoint(canvas, pointA);
        AddPoint(canvas, pointB);
        AddPoint(canvas, pointC);

        // Create triangle and fill with corner points and random starting point
        Triangle triangle = new Models.Triangle();
        triangle.PointA = pointA;
        triangle.PointB = pointB;
        triangle.PointC = pointC;
        triangle.RandomStartingPoint = randomStartingPoint;

        return triangle;
    }

    /// <summary>
    /// Draws a point between a random corner point of the triangle and a starting point,
    /// then between that newly added point and another random corner point of the triangle
    /// and repeats the process.
    /// </summary>
    /// <param name="canvas">WPF canvas control</param>
    public static void CreateChaosTriangle(Canvas canvas)
    {
        Triangle triangle = CreateTriangle(canvas);
        Coordinates point = triangle.RandomStartingPoint;

        for (int i = 0; i < 200000; i++)
        {
            Coordinates randomPointOfTriangle = GetRandomPoint(triangle);
            point = CreateMiddlePoint(randomPointOfTriangle, point);
            // Don't add first 100 points to account for some points in the beginning being outside of the triangle
            if (i > 100)
                AddPoint(canvas, point);
        }
    }
}
