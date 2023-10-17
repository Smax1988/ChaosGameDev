using System.Collections.Generic;
using System.Drawing;

namespace ChaosGameLib.Models;

public class ShapeBase
{
    public List<Coordinates> AllPoints { get; set; } = new List<Coordinates>();
    public Coordinates RandomStartingPoint { get; set; } = new Coordinates();
}
