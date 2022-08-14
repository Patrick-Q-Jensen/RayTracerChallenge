namespace RayTracerChallenge;

public abstract class Pattern
{
    public Color A = new();
    public Color B = new();
    public Matrix Transformation = MathOperations.IdentityMatrix;

    public void Transform(Matrix m)
    {
        Transformation = m;
    }

    public abstract Color ColorAt(Point p);

}
//public class Striped : Pattern
//{
//    public Striped(Color a, Color b)
//    {
//        A = a;
//        B = b;
//    }

//    public Striped(Color a, Color b, Matrix transformation)
//    {
//        A = a;
//        B = b;
//        Transformation = transformation;
//    }

//    public override Color ColorAt(Point p)
//    {
//        if (Math.Floor(p.X) % 2 == 0)
//        {
//            return A;
//        }
//        else
//        {
//            return B;
//        }
//    }
//}
