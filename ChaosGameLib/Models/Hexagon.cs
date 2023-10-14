using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosGameLib.Models;

public class Hexagon : Square
{
    public Coordinates PointE { get; set; } = new Coordinates();
    public Coordinates PointF { get; set; } = new Coordinates();
}
