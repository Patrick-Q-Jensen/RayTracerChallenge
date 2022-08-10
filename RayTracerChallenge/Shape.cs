namespace RayTracerChallenge;

public abstract class Shape
{
    public Matrix Transformation = MathOperations.IdentityMatrix;
    public Material Material = new();

    public void SetTransformation(Matrix matrix)
    {
        Transformation = matrix;
    }

    public abstract Vector Normal(Point p);

    public abstract Intersections Intersections(Ray r);

    protected Ray ConvertRayToObjectSpace(Ray r)
    {
        return MathOperations.TransformRay(r, this.Transformation.Inverse());
    }

    protected Point ConvertPointToObjectSpace(Point p)
    {
        return MathOperations.MultiplyMatrixWithTuple(this.Transformation.Inverse(), p).ToPoint();
    }

}


