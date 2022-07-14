namespace RayTracerChallengeTestSuite;
public class CanvasTests
{
    [Fact]
    public void CreatingCanvas()
    {
        Canvas c = new(10, 20);
        c.Height.Should().Be(10);
        c.Width.Should().Be(20);
        Color expectedColor = new Color(0, 0, 0);
        foreach (Color pixel in c.Pixels) {
            MathOperations.TuplesEqual(expectedColor, pixel).Should().BeTrue();
        }
    }

    [Fact]
    public void WritePixel()
    {
        Canvas c = new(10, 20);
        Color red = new(1, 0, 0);
        c.WritePixelColor(red,2,3);
        c.GetPixelColor(2,3).Should().Be(red);
    }
}
