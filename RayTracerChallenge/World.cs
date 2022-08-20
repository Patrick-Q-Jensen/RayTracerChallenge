namespace RayTracerChallenge;

public class World
{
    public List<Shape> Shapes = new();
    public PointLight PointLight = new(new Point(-10, 10, -10), new Color(1, 1, 1));

    public World()
    {
        Shapes.Add(new Sphere(new Material(diffuse: 0.7, specular: 0.2, color: new Color(0.8, 1.0, 0.6))));
        Shapes.Add(new Sphere(MathOperations.Scaling(0.5, 0.5, 0.5)));
    }

    public Intersections IntersectRay(Ray r)
    {
        Intersections intersecs = new Intersections();
        foreach (Shape shape in Shapes)
        {
            intersecs.list.AddRange(shape.Intersections(r).list);
        }
        intersecs.list = intersecs.list.OrderBy(x => x.T).ToList();
        return intersecs;
    }

    public Color TraceRayColor(Ray r)
    {
        Intersections intersecs = IntersectRay(r);
        Intersection i = intersecs.FindHit();
        if (i == null) return new Color(0, 0, 0);
        IntersectionComputation ic = new(i, r);
        return MathOperations.ShadeHit(this, ic);
    }

    public bool IsShadowed(Point p)
    {
        Vector v = PointLight.Position - p;
        double distance = v.Magnitude();
        Vector direction = v.Normalize();
        Ray r = new Ray(p, direction);
        Intersections intersecs = IntersectRay(r);
        Intersection hit = intersecs.FindHit();
        if (hit == null) return false;
        if (hit.T < distance) return true;
        return false;
    }

    public Color ReflectColor(IntersectionComputation ic, int remainingReflections = 5)
    {
        return MathOperations.ReflectedColor(this, ic, remainingReflections);
    }
}
