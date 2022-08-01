namespace RayTracerChallenge;

public class Sphere : Shape
{
       
    public Sphere()
    {

    }

    public override Vector Normal(Point p)
    {
        return MathOperations.NormalOnSphere(this, p);
    }
}
