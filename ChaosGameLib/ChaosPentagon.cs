﻿using ChaosGameLib.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace ChaosGameLib;

/// <summary>
/// Class provides functionality to create a pentagon fractal.
/// </summary>
public class ChaosPentagon : ChaosBase
{
    /// <summary>
    /// Creates the fractal based on a pentagon as a MemoryStream
    /// </summary>
    /// <param name="iterations">Number of points added to the bitmap</param>
    /// <param name="imgWidth">Widht of BitmapImage</param>
    /// <param name="imgHeight">Height of BitmapImage</param>
    /// <param name="color">Color of the points</param>
    /// <returns>Fractal based on a pentagon as BitmapImage</returns>
    public static MemoryStream CreatePentagonMemoryStream(int iterations, int imgWidth, int imgHeight, Color color)
    {
        Bitmap bitmap = new Bitmap(imgWidth, imgHeight);
        Coordinates LastCornerPoint = new Coordinates();
        Pentagon pentagon = CreatePentagon(imgWidth, imgHeight, color);
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
        return CreateImageStream(bitmap);
    }

    /// <summary>
    /// Calculates the five corner points of the pentagon and the random starting point
    /// </summary>
    /// <param name="width">Widht of the bitmap where the fractal will be drawn</param>
    /// <param name="height">Height of the bitmap where the fractal will be drawn</param>
    /// <param name="color">Color for the random starting point</param>
    /// <returns>A pentagon with all its corner points and the random starting point</returns>
    private static Pentagon CreatePentagon(int width, int height, Color color)
    {
        int bitmapWidth = width;
        int bitmapHeight = height;
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
