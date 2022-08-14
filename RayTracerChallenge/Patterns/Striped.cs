namespace RayTracerChallenge;

public class Striped : Pattern
{
    public Striped(Color a, Color b) : base(a, b){}
    public Striped(Color a, Color b, Matrix transformation) : base(a, b, transformation){}

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
