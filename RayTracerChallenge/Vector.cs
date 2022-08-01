namespace RayTracerChallenge;

public class Vector : Tuple
{
    public Vector(double x, double y, double z) : base(x,y,z,0) {}

    public Vector Normalize()
    {
        return MathOperations.NormalizeVector(this);
    }

    public Vector Add(Vector v)
    {
        return MathOperations.AddTuples(v, this).ToVector();
    }

    public override Vector Negate()
    {
        return MathOperations.NegateTuple(this).ToVector();
    }

    
}

