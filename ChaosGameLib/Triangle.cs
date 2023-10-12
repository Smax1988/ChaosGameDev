using ChaosGameLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ChaosGameLib
{
    public class Triangle
    {
        /// <summary>
        /// Adds a Point with X and Y Coordinates to a canvas
        /// </summary>
        /// <param name="canvas">WPF Canvas</param>
        /// <param name="coordinates">X and Y Coordinates of the point and the color</param>
        public void AddPoint(Canvas canvas, Coordinates coordinates)
        {
            Ellipse newPoint = new Ellipse
            {
                Width = 5,
                Height = 5,
                Fill = coordinates.Color
            };

            Canvas.SetLeft(newPoint, coordinates.X);
            Canvas.SetTop(newPoint, coordinates.Y);

            canvas.Children.Add(newPoint);
        }

        /// <summary>
        /// Creates the initial equilateral triangle and the first random point
        /// </summary>
        public void CreateInitialTriangle(Canvas canvas)
        {
            double canvasWidth = canvas.ActualWidth;
            double canvasHeight = canvas.ActualHeight;

            AddPoint(canvas, new Coordinates { X = (int)canvasWidth, Y = (int)canvasHeight });
            //AddPoint(canvas, new Coordinates { X = (int)canvasWidth, Y = (int)canvasHeight });

        }
    }
}
