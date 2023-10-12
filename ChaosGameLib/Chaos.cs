using ChaosGameLib.Models;
using System;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ChaosGameLib;

public class Chaos
{
    /// <summary>
    ///  Creates the initial equilateral triangle and the first random point
    /// Canvas: Point (0,0) is top left, Point (width, height) is bottom right.
    /// </summary>
    /// <param name="canvas">WPF Canvas Control</param>
    /// <returns>The Created Triangle with all of its Points and the random generated starting point</returns>
    public static ChaosTriangle CreateTriangle(Canvas canvas)
    {
        int canvasWidth = (int)canvas.ActualWidth;
        int canvasHeight = (int)canvas.ActualHeight;
        int triangleLength = canvasWidth - 100;
        Random random = new Random();

        Coordinates pointA = new Coordinates
        {
            X = 50,
            Y = canvasHeight - 50
        };
        
        Coordinates pointB = new Coordinates
        {
            X = canvasWidth - 50,
            Y = canvasHeight - 50
        };

        Coordinates pointC = new Coordinates
        {   
            
            X = canvasWidth / 2,
            // Get height of equilateral triangle: Pythagoras
            Y = canvasHeight - (int)Math.Sqrt(Math.Pow(triangleLength, 2) - Math.Pow(triangleLength / 2, 2))
        };

        // Random Starting Point
        Coordinates randomStartingPoint = new Coordinates
        {
            X = random.Next(0, canvasWidth),
            Y = random.Next(0, canvasHeight),
        };

        AddPoint(canvas, pointA);
        AddPoint(canvas, pointB);
        AddPoint(canvas, pointC);
        AddPoint(canvas, randomStartingPoint);

        return new ChaosTriangle
        {
            PointA = pointA,
            PointB = pointB,
            PointC = pointC,
            RandomStartingPoint = randomStartingPoint
        };
    }

    public static void CreateChaos(Canvas canvas, ChaosTriangle triangle, Coordinates point)
    {
        for (int i = 0; i < 200000; i++)
        {
            Coordinates randomPointOfTriangle = GetRandomPoint(triangle);
            point = GetHalfLength(randomPointOfTriangle, point);
            AddPoint(canvas, point);
        }
    }

    /// <summary>
    /// Adds a Point with X and Y Coordinates to a canvas
    /// </summary>
    /// <param name="canvas">WPF Canvas</param>
    /// <param name="coordinates">X and Y Coordinates of the point and the color</param>
    public static void AddPoint(Canvas canvas, Coordinates coordinates)
    {
        Ellipse newPoint = new Ellipse
        {
            Width = 1,
            Height = 1,
            Fill = coordinates.Color
        };

        Canvas.SetLeft(newPoint, coordinates.X);
        Canvas.SetTop(newPoint, coordinates.Y);

        canvas.Children.Add(newPoint);
    }

    private static Coordinates GetRandomPoint(ChaosTriangle triangle)
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 4); // min is included, max is excluded
        switch(randomNumber)
        {
            case 1:
                return triangle.PointA;
            case 2:
                return triangle.PointB;
            default:
                return triangle.PointC;
        }
    }

    private static Coordinates GetHalfLength(Coordinates trianglePoint, Coordinates randomPoint)
    {
        Random random = new Random();
        PropertyInfo[] properties = typeof(Brushes).GetProperties();

        return new Coordinates
        {
            X = (trianglePoint.X + randomPoint.X) / 2,
            Y = (trianglePoint.Y + randomPoint.Y) / 2,
            Color = (SolidColorBrush)properties[random.Next(properties.Length)].GetValue(null, null)!
        };
    }
}
