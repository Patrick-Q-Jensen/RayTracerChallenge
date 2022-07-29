namespace RayTracerChallenge;

public class Intersection
{
    public double T;
    public object IntersectionObject = null;

    public Intersection(double t, object intersectionObject)
    {
        T = t;
        IntersectionObject = intersectionObject;
    }
}

