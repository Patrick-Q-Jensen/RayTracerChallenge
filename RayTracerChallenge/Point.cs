namespace RayTracerChallenge;

public class Point : Tuple
{
    public Point(double x, double y, double z) : base(x,y,z,1) {}

    public Vector Subtract(Point p)
    {
        return new Vector(X - p.X, Y - p.Y, Z - p.Z);
    }

    public Point Add(Vector v)
    {
        return MathOperations.AddPointAndVector(this, v);
    }

    public static Point operator *(Point a, double b)
    {
        return MathOperations.MultiplyTuple(a, b).ToPoint();
    }

    public static Vector operator -(Point a, Point b)
    {
        return MathOperations.SubtractPoints(a, b);
    }

    public static Point operator +(Point a, Point b)
    {
        return MathOperations.AddTuples(a, b).ToPoint();
    }

    public static Point operator +(Point a, Vector b)
    {
        return MathOperations.AddPointAndVector(a, b);
    }
}

