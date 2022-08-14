namespace RayTracerChallenge;

public class Gradiant : Pattern
{
    public Gradiant(Color a, Color b) : base(a, b) { }
    public Gradiant(Color a, Color b, Matrix transformation) : base(a, b, transformation) { }

    public override Color ColorAt(Point p)
    {
        return A + (B - A) * (p.X - Math.Floor(p.X));
    }
}
