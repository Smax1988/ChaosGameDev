using System.Windows.Media;

namespace ChaosGameLib.Models;

public class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }
    public SolidColorBrush Color { get; set; } = Brushes.Cyan;

    public Coordinates() {}

    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }
}
