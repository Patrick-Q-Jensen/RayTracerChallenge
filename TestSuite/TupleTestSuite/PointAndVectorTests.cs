namespace RayTracerChallengeTestSuite;
public class PointAndVectorTests
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
        Vector p = new Vector(1.2f, 2.5f, 3);
        Assert.True(p.X == 1.2f);
        Assert.True(p.Y == 2.5f);
        Assert.True(p.Z == 3);
        Assert.True(p.W == 0);
    }
}