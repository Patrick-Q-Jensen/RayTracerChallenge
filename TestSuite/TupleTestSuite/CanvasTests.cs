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

    [Fact]
    public void ConversionToPPMHeader()
    {
        Canvas c = new(10, 20);
        string ppm = c.ConvertToPPM();
        
        using (var reader = new StringReader(ppm))
        {
            string first = reader.ReadLine();
            string second = reader.ReadLine();   
            string third = reader.ReadLine();
            first.Should().Be("P3");
            second.Should().Be("20 10");
            third.Should().Be("255");
        }
    }

    [Fact]
    public void ConversionToPPMPixelData()
    {
        Canvas c = new Canvas(3, 5);
        Color c1 = new Color(1.5,0,0);
        Color c2 = new Color(0, 0.5, 0);
        Color c3 = new Color(-0.5, 0, 1);
        c.WritePixelColor(c1, 0, 0);
        c.WritePixelColor(c2, 1, 2);
        c.WritePixelColor(c3, 2, 4);
        string ppm = c.ConvertToPPM();
        string[] lines = ppm.Split(new[] { '\n' });

        lines[3].Should().Be("255 0 0 0 0 0 0 0 0 0 0 0 0 0 0");
        lines[4].Should().Be("0 0 0 0 0 0 0 128 0 0 0 0 0 0 0");
        lines[5].Should().Be("0 0 0 0 0 0 0 0 0 0 0 0 0 0 255");
    }

    [Fact]
    public void ConversionToPPMMaxLineLength()
    {
        Canvas c = new Canvas(2, 10, new Color(1, 0.8, 0.6));
        string ppm = c.ConvertToPPM();
        string[] lines = ppm.Split(new[] { '\n' });

        lines[3].Should().Be("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153");
        lines[4].Should().Be("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153");
        lines[5].Should().Be("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153");
        lines[6].Should().Be("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153");
    }

    [Fact]
    public void ConversionToPPMEndswithNewlineCharacter()
    {
        Canvas c1 = new Canvas(2, 3);
        Canvas c2 = new Canvas(2, 10, new Color(1, 0.8, 0.6));
        Canvas c3 = new Canvas(18, 9);
        string ppm1 = c1.ConvertToPPM();
        string ppm2 = c2.ConvertToPPM();
        string ppm3 = c3.ConvertToPPM();
        ppm1.EndsWith("\n").Should().BeTrue();
        ppm2.EndsWith("\n").Should().BeTrue();
        ppm3.EndsWith("\n").Should().BeTrue();

    }
}
