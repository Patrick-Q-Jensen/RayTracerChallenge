namespace RayTracerChallenge;

public static class MathOperations {
    const double Epsilon = 0.00001f;
    private readonly static Tuple zeroTuple = new Tuple(0, 0, 0, 0);

    public static bool FloatingEquals(double a, double b) {
        if (Math.Abs(a-b) < Epsilon) return true;        
        return false;
    }

    public static bool TuplesEqual(Tuple a, Tuple b) {
        if (FloatingEquals(a.X, b.X) && FloatingEquals(a.Y, b.Y) && FloatingEquals(a.Z, b.Z)) return true;        
        return false;
    }

    public static Point AddPointAndVector(Point a, Vector b) {
        return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Tuple AddTuples(Tuple a, Tuple b)
    {
        return new Tuple(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    }

    public static Point SubtractVectorFromPoint(Point a, Vector b) {
        return new Point(a.X-b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vector SubtractPoints(Point a, Point b) {
        return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    //public static Vector SubtractVectors(Vector a, Vector b) {
    //    return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    //}

    public static Tuple SubtractTuples(Tuple a, Tuple b) {
        return new Tuple(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    }

    public static Tuple NegateTuple(Tuple t) {      
        return SubtractTuples(zeroTuple, t);
    }

    public static Tuple MultiplyTuple(Tuple t, double multiplier) {
        return new Tuple(t.X * multiplier, t.Y * multiplier, t.Z * multiplier, t.W * multiplier);
    }

    public static Tuple DivideTuple(Tuple t, double divisor) {
        return new Tuple(t.X/divisor, t.Y/divisor, t.Z/divisor, t.W/divisor);
    }

    public static double VectorMagnitude(Vector v) {
        double magnitude = Math.Sqrt((Math.Pow(v.X, 2) + Math.Pow(v.Y, 2) + Math.Pow(v.Z, 2) + Math.Pow(v.W, 2)));
        return magnitude;
    }

    public static Vector NormalizeVector(Vector v) {
        double magnitude = VectorMagnitude(v);
        return new(v.X/magnitude, v.Y/magnitude, v.Z/magnitude);
    }

    public static double VectorsDotProduct(Vector a, Vector b)
    {
        return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z) + (a.W * b.W);
    }

    public static Color MultiplyColors(Color a, Color b)
    {
        return new Color(a.Red * b.Red, a.Green * b.Green, a.Blue * b.Blue);
    }

    public static Vector VectorsCrossProduct(Vector a, Vector b)
    {
        return new Vector(
            a.Y * b.Z - a.Z * b.Y, 
            a.Z * b.X - a.X * b.Z, 
            a.X * b.Y - a.Y * b.X);
    }

}

