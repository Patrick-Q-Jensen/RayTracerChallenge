namespace RayTracerChallenge;

public class Tuple {
    public double X, Y, Z;
    protected double w;
    public double W => w;

    public Tuple(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        this.w = w;
    }
    
    public Vector ToVector()
    {
        return new Vector(X, Y, Z);
    }

    public Point ToPoint()
    {
        return new Point(X, Y, Z);
    }

    public Color ToColor()
    {
        return new Color(X, Y, Z);
    }

    public virtual Tuple Negate()
    {
        return MathOperations.NegateTuple(this);
    }

    public virtual Tuple Add(Tuple t)
    {
        return MathOperations.AddTuples(this, t);
    }
}


