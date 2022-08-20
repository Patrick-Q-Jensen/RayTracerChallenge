namespace RayTracerChallenge;

public class Checkered : Pattern
{
    public Checkered(Color a, Color b) : base(a, b) { }
    public Checkered(Color a, Color b, Matrix transformation) : base(a, b, transformation) { }

    public override Color ColorAt(Point p)
    {
        if ((Math.Floor(p.X) + Math.Floor(p.Y) + Math.Floor(p.Z)) % 2 == 0)
        {
            return A;
        }
        return B;
    }
}
