namespace RayTracerChallenge;

public class Color : Tuple
{
    public double Red => X;
    public double Green => Y;
    public double Blue => Z;

    public Color(double red = 0, double green = 0, double blue = 0) : base(red, green, blue, 0)
    {

    }
}
