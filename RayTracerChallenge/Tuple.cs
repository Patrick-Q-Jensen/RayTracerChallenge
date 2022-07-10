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
}

