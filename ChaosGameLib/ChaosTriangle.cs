﻿using ChaosGameLib.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace ChaosGameLib;

/// <summary>
/// Class provides functionality to create a triangle fractal.
/// </summary>
public class ChaosTriangle : ChaosBase
{
    /// <summary>
    /// Creates the fractal based on a triangle as a MemoryStream
    /// </summary>
    /// <param name="iterations">Number of points added to the bitmap</param>
    /// <param name="imgWidth">Widht of BitmapImage</param>
    /// <param name="imgHeight">Height of BitmapImage</param>
    /// <param name="color">Color of the points</param>
    /// <returns>Fractal based on a triangle as BitmapImage</returns>
    public static MemoryStream CreateTriangleMemoryStream(int iterations, int imgWidth, int imgHeight, Color color)
    {
        Bitmap bitmap = new Bitmap(imgWidth, imgHeight);
        Triangle triangle = CreateTriangle(imgWidth, imgHeight, color);
        Coordinates point = triangle.RandomStartingPoint;

        for (int i = 0; i < iterations; i++)
        {
            Coordinates randomCornerPoint = GetRandomCornerPoint(triangle);
            point = CreateMiddlePoint(randomCornerPoint, point);
            // Don't add first 100 points to account for some points in the beginning being outside of the triangle
            if (i > 100)
                AddPoint(bitmap, point);
        }
        return CreateImageStream(bitmap);
    }


    /// <summary>
    /// Calculates the three corner points of the triangle and the random starting point
    /// </summary>
    /// <param name="width">Widht of the bitmap where the fractal will be drawn</param>
    /// <param name="height">Height of the bitmap where the fractal will be drawn</param>
    /// <param name="color">Color for the random starting point</param>
    /// <returns>A triangle with all its corner points and the random starting point</returns>
    private static Triangle CreateTriangle(int width, int height, Color color)
    {
        int bitmapWidth = width;
        int bitmapHeight = height;
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
