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

    public Vector Subtract(Vector v)
    {
        return MathOperations.SubtractTuples(this, v).ToVector();
    }

    public Vector Multiply(double m)
    {
        return MathOperations.MultiplyVector(this, m);
    }

    public static Vector operator *(Vector a, double b)
    {
        return MathOperations.MultiplyVector(a, b);
    }

    public static Vector operator -(Vector a, Vector b)
    {
        return MathOperations.SubtractTuples(a, b).ToVector();
    }

    public static Vector operator +(Vector a, Vector b)
    {
        return MathOperations.AddTuples(a, b).ToVector();
    }

    public double Magnitude()
    {
        return MathOperations.VectorMagnitude(this);
    }
}

