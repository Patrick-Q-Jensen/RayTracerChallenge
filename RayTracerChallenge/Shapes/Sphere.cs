namespace RayTracerChallenge;

public class Sphere : Shape
{
       
    public Sphere()
    {

    }

    public Sphere(Material material)
    {
        Material = material;
    }

    public Sphere(Matrix transformation)
    {
        SetTransformation(transformation);
    }

    protected override Intersections LocalIntersections(Ray r)
    {
        return MathOperations.SphereIntersections(this, r);
    }

    protected override Vector LocalNormal(Point localPoint)
    {
        return localPoint - new Point(0, 0, 0);
    }
}
