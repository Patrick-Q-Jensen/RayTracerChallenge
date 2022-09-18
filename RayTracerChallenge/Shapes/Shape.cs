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

    public Color ColorAt(Point p)
    {
        if (Material.Pattern is not null)
        {
            Point localPoint = ConvertPointToObjectSpace(p);
            Point patternPoint = Material.Pattern.Transformation.Inverse() * localPoint;
            return Material.Pattern.ColorAt(patternPoint);
        }
        return Material.Color;
    }

    private Point ConvertPointToObjectSpace(Point p)
    {
        return Transformation.Inverse() * p;
    }

    protected abstract Vector LocalNormal(Point localPoint);
    protected abstract Intersections LocalIntersections(Ray r);

}


