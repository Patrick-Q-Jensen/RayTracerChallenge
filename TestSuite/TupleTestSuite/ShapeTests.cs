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
}
