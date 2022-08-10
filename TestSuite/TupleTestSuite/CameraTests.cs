namespace RayTracerChallengeTestSuite;

public class CameraTests
{
    [Fact]
    public void CameraConstructor()
    {
        Camera c = new(160, 120, Math.PI / 2);
        c.Hsize.Should().Be(160);
        c.Vsize.Should().Be(120);
        c.FieldOfView.Should().Be(Math.PI / 2);
        c.Tranformation.Equals(MathOperations.IdentityMatrix).Should().BeTrue();

    }

    [Fact]
    public void PixelSizeForHorizontalCanvas()
    {
        Camera c = new(200, 125, Math.PI / 2);
        MathOperations.FloatingEquals(c.PixelSize, 0.01).Should().BeTrue();
    }

    [Fact]
    public void PixelSizeForVerticalCanvas()
    {
        Camera c = new(125, 200, Math.PI / 2);
        MathOperations.FloatingEquals(c.PixelSize, 0.01).Should().BeTrue();
    }

    [Fact]
    public void RayThroughCenterOfCanvas()
    {
        Camera c = new(201, 101, Math.PI / 2);
        Ray r = c.RayForPixel(100, 50);        
        r.Origin.Equals(new Point(0, 0, 0)).Should().BeTrue();
        r.Direction.Equals(new Vector(0, 0, -1)).Should().BeTrue();
    }

    [Fact]
    public void RayThroughCornerOfCanvas()
    {
        Camera c = new(201, 101, Math.PI / 2);
        Ray r = c.RayForPixel(0, 0);
        r.Origin.Equals(new Point(0, 0, 0)).Should().BeTrue();
        r.Direction.Equals(new Vector(0.66519, 0.33259, -0.66851)).Should().BeTrue();
    }

    [Fact]
    public void RayWhenCameraIsTransformed()
    {
        Camera c = new(201, 101, Math.PI / 2);
        c.Tranformation = MathOperations.Rotation_Y(MathOperations.Degrees(Math.PI / 4)) * MathOperations.Translation(0, -2, 5);
        Ray r = c.RayForPixel(100, 50);
        r.Origin.Equals(new Point(0, 2, -5)).Should().BeTrue();
        r.Direction.Equals(new Vector(Math.Sqrt(2) / 2, 0, -Math.Sqrt(2) / 2)).Should().BeTrue();
    }

    [Fact]
    public void RenderingWorldWithCamera()
    {
        World w = new World();
        Camera c = new Camera(11, 11, Math.PI / 2);
        Point from = new Point(0, 0, -5);
        Point to = new Point(0, 0, 0);
        Vector up = new Vector(0, 1, 0);
        c.Tranformation = MathOperations.ViewTransform(from, to, up);
        Canvas image = c.Render(w);
        Color color = image.GetPixelColor(5, 5);
        color.Equals(new Color(0.38066, 0.47583, 0.2855)).Should().BeTrue();
        //image.GetPixelColor(5,5).Equals
    }
}
