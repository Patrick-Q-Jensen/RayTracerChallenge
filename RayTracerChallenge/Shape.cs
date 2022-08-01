namespace RayTracerChallenge;

public abstract class Shape
{
    private Matrix transformation = MathOperations.IdentityMatrix;
    public Material Material = new Material();
    public Matrix Transformation => transformation;

    public void SetTransformation(Matrix matrix)
    {
        transformation = matrix;
    }

    public abstract Vector Normal(Point p);

}
