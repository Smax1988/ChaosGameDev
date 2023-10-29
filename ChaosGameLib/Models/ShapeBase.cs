using System.Collections.Generic;
using System.Drawing;

namespace ChaosGameLib.Models;

/// <summary>
/// Base class that provides all points of a geometric figure and the random starting point needed to create a fractal.
/// </summary>
public class ShapeBase
{
    public List<Coordinates> AllPoints { get; set; } = new List<Coordinates>();
    public Coordinates RandomStartingPoint { get; set; } = new Coordinates();
}
