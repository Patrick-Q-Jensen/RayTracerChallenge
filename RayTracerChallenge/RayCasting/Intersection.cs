namespace RayTracerChallenge;

public class Intersection
{
    public double T;
    public Shape Shape = null;

    public Intersection(double t, Shape intersectionObject)
    {
        T = t;
        Shape = intersectionObject;
    }
}

public class Intersections
{
    public List<Intersection> list = new();

    public Intersections(List<Intersection>? intersections = null)
    {
        if (intersections == null) return;
        list = intersections;
    }

    public Intersection FindHit()
    {
        return MathOperations.FindHit(this);
    }
}

