namespace RayTracerChallenge;

public class Striped : Pattern
{
    public Striped(Color a, Color b)
    {
        A = a;
        B = b;
    }

    public Striped(Color a, Color b, Matrix transformation)
    {
        A = a;
        B = b;
        Transformation = transformation;
    }

    public override Color ColorAt(Point p)
    {
        if (Math.Floor(p.X) % 2 == 0)
        {
            return A;
        }
        else
        {
            return B;
        }
    }
}
