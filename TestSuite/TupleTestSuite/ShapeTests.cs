namespace RayTracerChallengeTestSuite;

public class ShapeTests
{
    [Fact]
    public void SphereDefaultTransformation()
    {
        Sphere s = new Sphere();
        Matrix identityMatrix = MathOperations.IdentityMatrix;
        MathOperations.MatricesEqual(identityMatrix, s.Transformation).Should().BeTrue();
    }

    [Fact]
    public void SphereDefaultMaterial()
    {
        Sphere s = new Sphere();
        s.Material.Equals(new Material()).Should().BeTrue();
    }

    [Fact]
    public void SetSphereMaterial()
    {
        Sphere s = new Sphere();
        Material mat = new Material(10, 10, 10, 10);
        s.Material = mat;
        s.Material.Equals(mat).Should().BeTrue();
    }

    [Fact]
    public void SetSphereTransformation()
    {
        Sphere s = new Sphere();
        Matrix t = MathOperations.Translation(2, 3, 4);
        s.SetTransformation(t);
        MathOperations.MatricesEqual(t, s.Transformation).Should().BeTrue();
    }

    [Fact]
    public void NormalOnPlaneIsSameEveryWhere()
    {
        Plane p = new Plane();
        Vector n1 = p.Normal(new Point(0, 0, 0));
        Vector n2 = p.Normal(new Point(10, 0, -10));
        Vector n3 = p.Normal(new Point(-5, 0, 150));
        n1.Equals(new Vector(0, 1, 0)).Should().BeTrue();
        n2.Equals(new Vector(0, 1, 0)).Should().BeTrue();
        n3.Equals(new Vector(0, 1, 0)).Should().BeTrue();
    }
}
