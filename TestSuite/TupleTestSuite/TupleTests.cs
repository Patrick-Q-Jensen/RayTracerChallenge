namespace RayTracerChallengeTestSuite;
public class TupleTests
{
    [Fact]
    public void PointConstructorTest()
    {
        Point p = new Point(1.2f, 2.5f, 3);
        Assert.True(p.X == 1.2f);
        Assert.True(p.Y == 2.5f);
        Assert.True(p.Z == 3);
        Assert.True(p.W == 1);
    }

    [Fact]
    public void VectorConstructorTest()
    {
        Vector v = new Vector(1.2f, 2.5f, 3);
        Assert.True(v.X == 1.2f);
        Assert.True(v.Y == 2.5f);
        Assert.True(v.Z == 3);
        Assert.True(v.W == 0);
    }

    [Fact]
    public void ColorConstructorTest()
    {
        Color c = new Color(-0.5, 0.4, 1.7);

        c.Red.Should().Be(-0.5);
        c.Green.Should().Be(0.4);
        c.Blue.Should().Be(1.7);
    }

}