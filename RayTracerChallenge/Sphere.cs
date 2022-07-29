namespace RayTracerChallenge;

public class Sphere
{
    private Matrix transformation;

    public Matrix Transformation => transformation;

    public Sphere(Matrix transformation = null)
    {
        if (transformation == null) {
            this.transformation = MathOperations.IdentityMatrix;
            return;
        }
        this.transformation = transformation;
    }

    public void SetTransformation(Matrix matrix)
    {
        transformation = matrix;
    }
}
