namespace RayTracerChallenge;

public class IntersectionComputation
{
    public Shape Shape { get; set; }
    public Point Point { get; set; }
    public Point OverPoint { get; set; }
    public Vector EyeV { get; set; }
    public Vector NormalV { get; set; }
    public Vector ReflectV { get; set; }
    public double T { get; set; }
    public bool Inside { get; set; }

    public IntersectionComputation(Intersection intersection, Ray ray)
    {
        T = intersection.T;
        Shape = intersection.Shape;
        Point = MathOperations.Position(ray, intersection.T);
        EyeV = ray.Direction.Negate();        
        NormalV = intersection.Shape.Normal(Point);
        ReflectV = MathOperations.Reflect(ray.Direction, NormalV);
        if (MathOperations.VectorsDotProduct(EyeV, NormalV) < 0) {
            Inside = true;
            NormalV = NormalV.Negate();
        }
        OverPoint = Point + (NormalV * MathOperations.Epsilon);
    }

    public Color ReflectColor(World w)
    {
        return MathOperations.ReflectedColor(w, this);
    }

}
