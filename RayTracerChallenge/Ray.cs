namespace RayTracerChallenge;

public class Ray
{
    public Point Origin;
    public Vector Direction;

    public Ray(Point origin, Vector direction)
    {
        Origin = origin;
        Direction = direction;
    }

    public Intersections Intersections(Sphere s)
    {
        return MathOperations.Intersections(s, this);
    }

    public Point Position(double t)
    {
        return MathOperations.Position(this, t);
    }
}
