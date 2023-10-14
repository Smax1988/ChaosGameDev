using ChaosGameLib.Models;
using System;
using System.Windows.Controls;

namespace ChaosGameLib;

public class ChaosHex : ChaosBase
{
    public static Hexagon CreateHexagon(Canvas canvas)
    {
        int canvasWidth = (int)canvas.ActualWidth;
        int canvasHeight = (int)canvas.ActualHeight;
        int centerLeftRight = canvasWidth / 2; // Center of the canvas horizontally
        int centerTopBottom = canvasHeight / 2; // Center of the canvas vertically
        int sideLength = 300;
        Random random = new Random();

        // Calculate the corner points of the hexagon
        Coordinates pointA = new Coordinates (centerLeftRight, centerTopBottom - sideLength );
        Coordinates pointB = new Coordinates (centerLeftRight + (int)(sideLength * Math.Sqrt(3) / 2), centerTopBottom - sideLength / 2 );
        Coordinates pointC = new Coordinates (centerLeftRight + (int)(sideLength * Math.Sqrt(3) / 2), centerTopBottom + sideLength / 2 );
        Coordinates pointD = new Coordinates (centerLeftRight, centerTopBottom + sideLength );
        Coordinates pointE = new Coordinates (centerLeftRight - (int)(sideLength * Math.Sqrt(3) / 2), centerTopBottom + sideLength / 2 );
        Coordinates pointF = new Coordinates (centerLeftRight - (int)(sideLength * Math.Sqrt(3) / 2), centerTopBottom - sideLength / 2 );
        // Random Starting Point
        Coordinates randomStartingPoint = new Coordinates(random.Next(0, canvasWidth), random.Next(0, canvasHeight));

        Hexagon hexagon = new Hexagon();
        hexagon.PointA = pointA;
        hexagon.PointB = pointB;
        hexagon.PointC = pointC;
        hexagon.PointD = pointD;
        hexagon.PointE = pointE;
        hexagon.PointF = pointF;
        hexagon.RandomStartingPoint = randomStartingPoint;

        return hexagon;
    }

    public static void CreateChaosHex(Canvas canvas, int iterations)
    {
        Coordinates LastCornerPoint = new Coordinates();
        Hexagon hexaxon = CreateHexagon(canvas);
        Coordinates point = hexaxon.RandomStartingPoint;

        for (int i = 0; i < iterations; i++)
        {
            Coordinates randomCornerPoint = GetRandomPoint(hexaxon);
            if (randomCornerPoint != LastCornerPoint)
            {
                point = CreateMiddlePoint(randomCornerPoint, point);
                LastCornerPoint = randomCornerPoint;

                if (i > 100)
                    AddPoint(canvas, point);
            }
        }
    }

    protected static Coordinates GetRandomPoint(Hexagon hexagon)
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 7); // min is included, max is excluded
        switch (randomNumber)
        {
            case 1:
                return hexagon.PointA;
            case 2:
                return hexagon.PointB;
            case 3:
                return hexagon.PointC;
            case 4:
                return hexagon.PointD;
            case 5:
                return hexagon.PointE;
            default:
                return hexagon.PointF;
        }
    }
}
