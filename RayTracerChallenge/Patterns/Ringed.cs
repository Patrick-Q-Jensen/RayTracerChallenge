namespace RayTracerChallenge;

public class Ringed : Pattern
{
    public Ringed(Color a, Color b) : base(a, b) { }
    public Ringed(Color a, Color b, Matrix transformation) : base(a, b, transformation) { }

    public override Color ColorAt(Point p)
    {
        double squaredX = Math.Pow(p.X, 2);
        double squaredZ = Math.Pow(p.Z, 2);

        if (Math.Floor(Math.Sqrt(squaredX + squaredZ)) % 2 == 0)
        {
            return A;
        }
        else
        {
            return B;
        }
    }
}
