using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosGameLib.Models
{
    public class ChaosTriangle
    {
        public Coordinates PointA { get; set; } = new Coordinates { X = 0, Y = 0 };
        public Coordinates PointB { get; set; } = new Coordinates { X = 0, Y = 0 };
        public Coordinates PointC { get; set; } = new Coordinates { X = 0, Y = 0 };
        public Coordinates RandomStartingPoint { get; set; } = new Coordinates { X = 0, Y = 0 };
    }
}
