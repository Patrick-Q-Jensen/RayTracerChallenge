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

    public Point Position(double t)
    {
        return MathOperations.Position(this, t);
    }

    public Ray Transform(Matrix m)
    {
        return MathOperations.TransformRay(this, m);
    }
}
