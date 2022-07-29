namespace RayTracerChallengeTestSuite;

public class RayCastingTests
{
    [Fact]
    public void CreatingAndQueryingRay()
    {
        Point origin = new Point(1, 2, 3);
        Vector direction = new Vector(4, 5, 6);
        Ray r = new Ray(origin, direction);
        MathOperations.TuplesEqual(origin, r.Origin).Should().BeTrue();
        MathOperations.TuplesEqual(direction, r.Direction).Should().BeTrue();
    }

    [Fact]
    public void ComputingPointFromDistance()
    {
        Ray r = new Ray(new Point(2, 3, 4), new Vector(1, 0, 0));
        Point p1 = MathOperations.Position(r, 0);
        Point p2 = MathOperations.Position(r, 1);
        Point p3 = MathOperations.Position(r, -1);
        Point p4 = MathOperations.Position(r, 2.5);

        MathOperations.TuplesEqual(p1, new Point(2, 3, 4));
        MathOperations.TuplesEqual(p2, new Point(3, 3, 4));
        MathOperations.TuplesEqual(p3, new Point(1, 3, 4));
        MathOperations.TuplesEqual(p4, new Point(4.5, 3, 4));
    }

    [Fact]
    public void RayIntersectingWithSphere()
    {
        Ray r = new Ray(new Point(0, 1, -5), new Vector(0, 0, 1));
        Sphere s = new Sphere();
        List<Intersection> intersections = MathOperations.Intersections(s, r);
        intersections.Count().Should().Be(2);
        intersections[0].T.Should().Be(5);
        intersections[1].T.Should().Be(5);
    }

    [Fact]
    public void RayMissingSphere()
    {
        Ray r = new Ray(new Point(0, 3, -5), new Vector(0, 0, 1));
        Sphere s = new Sphere();
        List<Intersection> intersections = MathOperations.Intersections(s, r);
        intersections.Count.Should().Be(0);
    }

    [Fact]
    public void RayOriginatingInSphere()
    {
        Ray r = new Ray(new Point(0, 0, 0), new Vector(0, 0, 1));
        Sphere s = new Sphere();
        List<Intersection> intersections = MathOperations.Intersections(s, r);
        intersections.Count().Should().Be(2);
        intersections[0].T.Should().Be(-1.0d);
        intersections[1].T.Should().Be(1.0d);
    }

    [Fact]
    public void SphereBehindRay()
    {
        Ray r = new Ray(new Point(0, 0, 5), new Vector(0, 0, 1));
        Sphere s = new Sphere();
        List<Intersection> intersections = MathOperations.Intersections(s, r);
        intersections.Count.Should().Be(2);
        intersections[0].T.Should().Be(-6.0d);
        intersections[1].T.Should().Be(-4.0d);
    }

    [Fact]
    public void InterSectionEncapsulatesObjectAndT()
    {
        Sphere s = new Sphere();
        Intersection intsec = new Intersection(3.5, s);
        intsec.T.Should().Be(3.5);
        intsec.IntersectionObject.Should().Be(s);
    }

    [Fact]
    public void AggregratingIntersections()
    {
        Sphere s = new Sphere();
        Intersection intsec1 = new Intersection(1, s);
        Intersection intsec2 = new Intersection(2, s);
        List<Intersection> intersecs = new List<Intersection>();
        intersecs.Add(intsec1);
        intersecs.Add(intsec2);
        intersecs.Count.Should().Be(2);
        intersecs[0].T.Should().Be(1);
        intersecs[1].T.Should().Be(2);
    }

    [Fact]
    public void IntersectSettingObjectOnIntersection()
    {
        Ray r = new Ray(new Point(0, 0, 5), new Vector(0, 0, 1));
        Sphere s = new Sphere();
        Intersection intsec1 = new Intersection(1, r);
        MathOperations.Intersections(s, r);
    }

    [Fact]
    public void HitWhenAllIntersectionsHavePositiveTValue()
    {
        Sphere s = new Sphere();
        Intersection intsec1 = new(1, s);
        Intersection intsec2 = new(2, s);
        List<Intersection> intersecs = new() { intsec1, intsec2 };
        Intersection hit = MathOperations.FindHit(intersecs);
        hit.Should().Be(intsec1);
    }

    [Fact]
    public void HitWhenSomeIntersectionsHaveNegativeTValue()
    {
        Sphere s = new Sphere();
        Intersection intsec1 = new(-1, s);
        Intersection intsec2 = new(1, s);
        List<Intersection> intersecs = new() { intsec1, intsec2 };
        Intersection hit = MathOperations.FindHit(intersecs);
        hit.Should().Be(intsec2);
    }

    [Fact]
    public void HitWhenAllIntersectionsHaveNegativeTValue()
    {
        Sphere s = new Sphere();
        Intersection intsec1 = new(-2, s);
        Intersection intsec2 = new(-1, s);
        List<Intersection> intersecs = new() { intsec1, intsec2 };
        Intersection hit = MathOperations.FindHit(intersecs);
        hit.Should().Be(null);
    }

    [Fact]
    public void HitShouldAlwaysBeLowerNonNegativeTValueIntersection()
    {
        Sphere s = new Sphere();
        Intersection intsec1 = new(5, s);
        Intersection intsec2 = new(7, s);
        Intersection intsec3 = new(-3, s);
        Intersection intsec4 = new(2, s);
        List<Intersection> intersecs = new() { intsec1, intsec2, intsec3, intsec4 };
        Intersection hit = MathOperations.FindHit(intersecs);
        hit.Should().Be(intsec4);
    }

    [Fact]
    public void TranslatingRay()
    {
        Ray r = new Ray(new Point(1, 2, 3), new Vector(0, 1, 0));
        Matrix m = MathOperations.Translation(3, 4, 5);
        Ray r2 = MathOperations.TransformRay(r, m);
        MathOperations.TuplesEqual(r2.Origin, new Point(4, 6, 8));
        MathOperations.TuplesEqual(r2.Direction, new Vector(0, 1, 0));
    }

    [Fact]
    public void ScalingRay()
    {
        Ray r = new Ray(new Point(1, 2, 3), new Vector(0, 1, 0));
        Matrix m = MathOperations.Scaling(2, 3, 4);
        Ray r2 = MathOperations.TransformRay(r, m);
        MathOperations.TuplesEqual(r2.Origin, new Point(2, 6, 12));
        MathOperations.TuplesEqual(r2.Direction, new Vector(0, 3, 0));
    }

    [Fact]
    public void SphereDefaultTransformation()
    {
        Sphere s = new Sphere();
        Matrix identityMatrix = MathOperations.IdentityMatrix;
        MathOperations.MatricesEqual(identityMatrix, s.Transformation).Should().BeTrue();
    }

    [Fact]
    public void SetSphereTransformation()
    {
        Sphere s = new Sphere();
        Matrix t = MathOperations.Translation(2, 3, 4);
        s.SetTransformation(t);
        MathOperations.MatricesEqual(t, s.Transformation);
    }

    [Fact]
    public void RayIntersectingScaledSphere()
    {
        Ray r = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
        Sphere s = new Sphere();
        s.SetTransformation(MathOperations.Scaling(2, 2, 2));
        List<Intersection> intersecs = MathOperations.Intersections(s, r);
        intersecs.Count.Should().Be(2);
        intersecs[0].T.Should().Be(3);
        intersecs[1].T.Should().Be(7);
    }

    [Fact]
    public void NormalVectorOnSphereOnXAxis()
    {
        Sphere s = new Sphere();
        Vector normal = MathOperations.NormalOnSphere(s, new Point(1, 0, 0));
        MathOperations.TuplesEqual(normal, new Vector(1, 0, 0)).Should().BeTrue();
    }

    [Fact]
    public void NormalVectorOnSphereOnYAxis()
    {
        Sphere s = new Sphere();
        Vector normal = MathOperations.NormalOnSphere(s, new Point(0, 1, 0));
        MathOperations.TuplesEqual(normal, new Vector(0, 1, 0)).Should().BeTrue();
    }

    [Fact]
    public void NormalVectorOnSphereOnZAxis()
    {
        Sphere s = new Sphere();
        Vector normal = MathOperations.NormalOnSphere(s, new Point(0, 0, 1));
        MathOperations.TuplesEqual(normal, new Vector(0, 0, 1)).Should().BeTrue();
    }

    [Fact]
    public void NormalVectorOnSphereOnNonAxialPoint()
    {
        Sphere s = new Sphere();
        Vector normal = MathOperations.NormalOnSphere(s, new Point(Math.Sqrt(3)/3, Math.Sqrt(3) / 3, Math.Sqrt(3)/3));
        MathOperations.TuplesEqual(normal, new Vector(Math.Sqrt(3) / 3, Math.Sqrt(3) / 3, Math.Sqrt(3) / 3)).Should().BeTrue();
    }

    [Fact]
    public void NormalVectorIsNormalized()
    {
        Sphere s = new Sphere();
        Vector normal = MathOperations.NormalOnSphere(s, new Point(Math.Sqrt(3) / 3, Math.Sqrt(3) / 3, Math.Sqrt(3) / 3));
        MathOperations.TuplesEqual(normal, MathOperations.NormalizeVector(normal)).Should().BeTrue();
    }

    [Fact]
    public void ComputingNormalOnTranslatedSphere()
    {
        Sphere s = new Sphere();
        s.SetTransformation(MathOperations.Translation(0, 1, 0));
        Vector normal = MathOperations.NormalOnSphere(s, new Point(0, 1.70711, -0.70711));
        MathOperations.TuplesEqual(normal, new Vector(0, 0.70711, -0.70711)).Should().BeTrue();
    }

    [Fact]
    public void ComputingNormalOnTranformedSphere()
    {
        Sphere s = new Sphere();
        Matrix m = MathOperations.MultiplyMatrices(
            MathOperations.Scaling(1, 0.5, 1), 
            MathOperations.Rotation_Z(MathOperations.Degrees(Math.PI/5)));
        s.SetTransformation(m);
        Vector n = MathOperations.NormalOnSphere(s, new Point(0, Math.Sqrt(2) / 2, -Math.Sqrt(2) / 2));
        MathOperations.TuplesEqual(n, new Vector(0, 0.97014, -0.24254));
    }
}
