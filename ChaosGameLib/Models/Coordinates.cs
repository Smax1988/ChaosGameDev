using System.Windows.Media;

namespace ChaosGameLib.Models;

public class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }
    public SolidColorBrush Color { get; set; } = Brushes.White;
}
