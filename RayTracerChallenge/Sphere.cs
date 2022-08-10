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
        this.SetTransformation(transformation);
    }

    public override Vector Normal(Point p)
    {
        Point objectPoint = ConvertPointToObjectSpace(p);
        return MathOperations.NormalOnSphere(this, objectPoint);
    }

    public override Intersections Intersections(Ray r)
    {
        Ray r2 = ConvertRayToObjectSpace(r);
        return MathOperations.SphereIntersections(this, r2);
    }
}
