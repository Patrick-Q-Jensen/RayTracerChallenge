namespace RayTracerChallenge;

public static class MathOperations {
    const float Epsilon = 0.00001f;
    private readonly static Tuple zeroTuple = new Tuple(0, 0, 0, 0);

    public static bool FloatingEquals(float a, float b) {
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

    public static Vector AddVectors(Vector a, Vector b) {
        return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Point SubtractVectorFromPoint(Point a, Vector b) {
        return new Point(a.X-b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vector SubtractPoints(Point a, Point b) {
        return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vector SubtractVectors(Vector a, Vector b) {
        return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Tuple SubtractTuples(Tuple a, Tuple b) {
        return new Tuple(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    }

    public static Tuple NegateTuple(Tuple t) {      
        return SubtractTuples(zeroTuple, t);
    }

    public static Tuple MultiplyTuple(Tuple t, float multiplier) {
        return new Tuple(t.X * multiplier, t.Y * multiplier, t.Z * multiplier, t.W * multiplier);
    }

    public static Tuple DivideTuple(Tuple t, float divisor) {
        return new Tuple(t.X/divisor, t.Y/divisor, t.Z/divisor, t.W/divisor);
    }

}

