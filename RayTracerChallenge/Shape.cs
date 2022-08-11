namespace RayTracerChallenge;

public abstract class Shape
{
    public Matrix Transformation = MathOperations.IdentityMatrix;
    public Material Material = new();

    public void SetTransformation(Matrix matrix)
    {
        Transformation = matrix;
    }
    public Vector Normal(Point p)
    {
        Point localPoint = ConvertPointToObjectSpace(p);
        Vector localNormal = LocalNormal(localPoint);
        Vector worldNormal = Transformation.Inverse().Transpose() * localNormal;
        return worldNormal.Normalize();
    }

    public Intersections Intersections(Ray r)
    {
        Ray r2 = ConvertRayToObjectSpace(r);
        return LocalIntersections(r2);
    }

    private Ray ConvertRayToObjectSpace(Ray r)
    {
        return MathOperations.TransformRay(r, this.Transformation.Inverse());
    }

    private Point ConvertPointToObjectSpace(Point p)
    {
        return MathOperations.MultiplyMatrixWithTuple(this.Transformation.Inverse(), p).ToPoint();
    }

    protected abstract Vector LocalNormal(Point localPoint);
    protected abstract Intersections LocalIntersections(Ray r);

}


