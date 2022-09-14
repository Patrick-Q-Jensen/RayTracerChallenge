namespace RayTracerChallenge;

public class IntersectionComputations
{
    public List<Shape> Shapes = new();
    public Shape Shape;
    public double n1 = 0;
    public double n2 = 0;
    public Point underPoint;
    public Point point;
    public Vector NormalV;
    public Vector ReflectV;
    public double T;
    public Vector EyeV;
    public Point OverPoint;
    public bool Inside;

    public IntersectionComputations(Intersection hit, Ray r, Intersections intersecs)
    {
        T = hit.T;
        Shape = hit.Shape;
        point = r.Position(T);
        EyeV = r.Direction.Negate();
        NormalV = hit.Shape.Normal(point);
        
        if (MathOperations.VectorsDotProduct(EyeV, NormalV) < 0)
        {
            Inside = true;
            NormalV = NormalV.Negate();
        }
        
        DefineNValues(hit, intersecs.list);

        ReflectV = MathOperations.Reflect(r.Direction, NormalV);
        OverPoint = point + NormalV * MathOperations.Epsilon;
        underPoint = point - NormalV * MathOperations.Epsilon;
    }

    private void DefineNValues(Intersection hit, List<Intersection> intersecs)
    {
        foreach (Intersection i in intersecs)
        {
            if (hit == i)
            {
                if (!Shapes.Any())
                {
                    n1 = 1.0;
                }
                else
                {
                    n1 = Shapes.Last().Material.Refractive;
                }
            }

            if (Shapes.Where(x => x == i.Shape).Any())
            {
                Shapes.Remove(i.Shape);
            }
            else
            {
                Shapes.Add(i.Shape);
            }

            if (i == hit)
            {
                if (!Shapes.Any())
                {
                    n2 = 1.0;
                }
                else
                {
                    n2 = Shapes.Last().Material.Refractive;
                }
            }
        }
    }
}
