namespace ChaosGameLib.Models
{
    public class Pentagon : Square
    {
        public Coordinates PointE { get; set; } = new Coordinates();

        public Pentagon(Coordinates pointA, 
                        Coordinates pointB, 
                        Coordinates pointC, 
                        Coordinates pointD, 
                        Coordinates pointE) 
                        : base(pointA, pointB, pointC, pointD)
        {
            PointE = pointE;
            AllPoints.Add(pointE);
        }
    }
}
