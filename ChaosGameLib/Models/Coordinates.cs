using System.Drawing;

namespace ChaosGameLib.Models;

public class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }
    public Color Color { get; set; } = Color.White;

    public Coordinates() {}

    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Coordinates(int x, int y, Color color)
    {
        X = x;
        Y = y;
        Color = color;
    }
}
