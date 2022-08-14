namespace RayTracerChallenge;

public class Gradiant : Pattern
{
    public Gradiant(Color a, Color b)
    {
        A = a;
        B = b;
    }

    public Gradiant(Color a, Color b, Matrix transformation)
    {
        A = a;
        B = b;
        Transformation = transformation;
    }

    public override Color ColorAt(Point p)
    {
        return A + (B - A) * (p.X - Math.Floor(p.X));
    }
}
