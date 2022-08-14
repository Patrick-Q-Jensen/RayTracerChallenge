namespace RayTracerChallenge;

public class Plane : Shape
{
    protected override Intersections LocalIntersections(Ray r)
    {
        Intersections intersecs = new Intersections();
        if (Math.Abs(r.Direction.Y) < MathOperations.Epsilon)
        {
            return intersecs;
        }

        double t = -r.Origin.Y / r.Direction.Y;
        Intersection i = new(t, this);
        intersecs.list.Add(i);
        return intersecs;
    }

    protected override Vector LocalNormal(Point localPoint)
    {
        return new Vector(0, 1, 0);
    }
}
