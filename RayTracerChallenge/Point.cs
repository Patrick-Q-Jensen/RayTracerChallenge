namespace RayTracerChallenge;

public class Point : Tuple
{
    public Point(double x, double y, double z) : base(x,y,z,1) {}

    public Vector Subtract(Point p)
    {
        return new Vector(X - p.X, Y - p.Y, Z - p.Z);
    }
       
}

