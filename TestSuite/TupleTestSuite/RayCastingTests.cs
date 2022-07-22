namespace RayTracerChallengeTestSuite;

public class RayCastingTests
{
    [Fact]
    public void CreatingAndQueryingRay()
    {
        Point origin = new Point(1, 2, 3);
        Vector direction = new Vector(4,5,6);
        Ray r = new Ray(origin, direction);
        MathOperations.TuplesEqual(origin, r.Origin).Should().BeTrue();
        MathOperations.TuplesEqual(direction, r.Direction).Should().BeTrue();
    }

    [Fact]
    public void ComputingPointFromDistance()
    {
        Ray r = new Ray(new Point(2, 3, 4), new Vector(1,0,0));
        Point p1 = MathOperations.Position(r, 0);
        Point p2 = MathOperations.Position(r, 1);
        Point p3 = MathOperations.Position(r, -1);
        Point p4 = MathOperations.Position(r, 2.5);

        MathOperations.TuplesEqual(p1, new Point(2, 3, 4));
        MathOperations.TuplesEqual(p2, new Point(3, 3, 4));
        MathOperations.TuplesEqual(p3, new Point(1, 3, 4));
        MathOperations.TuplesEqual(p4, new Point(4.5, 3, 4));
    }
}
