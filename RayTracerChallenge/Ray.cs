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
}
