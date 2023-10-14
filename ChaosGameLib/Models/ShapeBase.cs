using System.Drawing;

namespace ChaosGameLib.Models;

public class ShapeBase
{
    public Coordinates RandomStartingPoint { get; set; } = new Coordinates();
    public Bitmap? Image { get; set; }
}
