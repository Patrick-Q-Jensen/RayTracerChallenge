namespace RayTracerChallenge;

public class Color : Tuple
{
    public double Red => X;
    public double Green => Y;
    public double Blue => Z;

    public Color(double red = 0, double green = 0, double blue = 0) : base(red, green, blue, 0)
    {

    }

    public static Color White => new(1, 1, 1);
    public static Color Black => new(0, 0, 0);

    public Color Add(Color c)
    {
        return MathOperations.AddTuples(this, c).ToColor();
    }

    public Color Multiply(Color c)
    {
        return MathOperations.MultiplyColors(this, c);
    }

    public Color Multiply(double m)
    {
        return MathOperations.MultiplyTuple(this, m).ToColor();
    }

    public static Color operator *(Color a, double b)
    {
        return MathOperations.MultiplyTuple(a, b).ToColor();
    }

    public static Color operator *(Color a, Color b)
    {
        return MathOperations.MultiplyColors(a, b);
    }

    public static Color operator -(Color a, Color b)
    {
        return MathOperations.SubtractTuples(a, b).ToColor();
    }

    public static Color operator +(Color a, Color b)
    {
        return MathOperations.AddTuples(a, b).ToColor();
    }

}
