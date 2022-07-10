namespace RayTracerChallenge;

public class Tuple {
    public float X, Y, Z;
    protected float w;
    public float W => w;

    public Tuple(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        this.w = w;
    }
}

