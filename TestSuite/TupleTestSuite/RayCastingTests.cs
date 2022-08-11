﻿namespace RayTracerChallengeTestSuite;

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

        MathOperations.TuplesEqual(p1, new Point(2, 3, 4)).Should().BeTrue();
        MathOperations.TuplesEqual(p2, new Point(3, 3, 4)).Should().BeTrue();
        MathOperations.TuplesEqual(p3, new Point(1, 3, 4)).Should().BeTrue();
        MathOperations.TuplesEqual(p4, new Point(4.5, 3, 4)).Should().BeTrue();
    }

    [Fact]
    public void RayIntersectingWithSphere()
    {
        Ray r = new Ray(new Point(0, 1, -5), new Vector(0, 0, 1));
        Sphere s = new Sphere();
        //Intersections intersections = MathOperations.SphereIntersections(s, r);
        Intersections intersections = s.Intersections(r);
        intersections.list.Count().Should().Be(2);
        intersections.list[0].T.Should().Be(5);
        intersections.list[1].T.Should().Be(5);
    }

    [Fact]
    public void RayMissingSphere()
    {
        Ray r = new Ray(new Point(0, 3, -5), new Vector(0, 0, 1));
        Sphere s = new Sphere();
        //Intersections intersections = MathOperations.SphereIntersections(s, r);
        Intersections intersections = s.Intersections(r);
        intersections.list.Count.Should().Be(0);
    }

    [Fact]
    public void RayOriginatingInSphere()
    {
        Ray r = new Ray(new Point(0, 0, 0), new Vector(0, 0, 1));
        Sphere s = new Sphere();
        Intersections intersections = s.Intersections(r);
        intersections.list.Count().Should().Be(2);
        intersections.list[0].T.Should().Be(-1.0d);
        intersections.list[1].T.Should().Be(1.0d);
    }

    [Fact]
    public void SphereBehindRay()
    {
        Ray r = new Ray(new Point(0, 0, 5), new Vector(0, 0, 1));
        Sphere s = new Sphere();
        Intersections intersections = s.Intersections(r);
        intersections.list.Count.Should().Be(2);
        intersections.list[0].T.Should().Be(-6.0d);
        intersections.list[1].T.Should().Be(-4.0d);
    }

    [Fact]
    public void InterSectionEncapsulatesObjectAndT()
    {
        Sphere s = new Sphere();
        Intersection intsec = new Intersection(3.5, s);
        intsec.T.Should().Be(3.5);
        intsec.Shape.Should().Be(s);
    }

    [Fact]
    public void AggregratingIntersections()
    {
        Sphere s = new Sphere();
        Intersection intsec1 = new Intersection(1, s);
        Intersection intsec2 = new Intersection(2, s);
        Intersections intersecs = new Intersections();
        intersecs.list.Add(intsec1);
        intersecs.list.Add(intsec2);
        intersecs.list.Count.Should().Be(2);
        intersecs.list[0].T.Should().Be(1);
        intersecs.list[1].T.Should().Be(2);
    }

    [Fact]
    public void IntersectSettingObjectOnIntersection()
    {
        Ray r = new(new Point(0, 0, 5), new Vector(0, 0, 1));
        Sphere s = new();
        //Intersection intsec1 = new(1, s);        
        Intersections intersecs = s.Intersections(r);
        intersecs.list[0].Shape.Should().Be(s);
        intersecs.list[1].Shape.Should().Be(s);
    }

    [Fact]
    public void HitWhenAllIntersectionsHavePositiveTValue()
    {
        Sphere s = new Sphere();
        Intersection intsec1 = new(1, s);
        Intersection intsec2 = new(2, s);
        Intersections intersecs = new Intersections( new() { intsec1, intsec2 });
        //Intersection hit = MathOperations.FindHit(intersecs);
        Intersection hit = intersecs.FindHit();
        hit.Should().Be(intsec1);
    }

    [Fact]
    public void HitWhenSomeIntersectionsHaveNegativeTValue()
    {
        Sphere s = new Sphere();
        Intersection intsec1 = new(-1, s);
        Intersection intsec2 = new(1, s);
        Intersections intersecs = new( new() { intsec1, intsec2 });
        Intersection hit = MathOperations.FindHit(intersecs);
        hit.Should().Be(intsec2);
    }

    [Fact]
    public void HitWhenAllIntersectionsHaveNegativeTValue()
    {
        Sphere s = new Sphere();
        Intersection intsec1 = new(-2, s);
        Intersection intsec2 = new(-1, s);
        Intersections intersecs = new Intersections(new() { intsec1, intsec2 });
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
        Intersections intersecs = new(new() { intsec1, intsec2, intsec3, intsec4 });
        //Intersection hit = MathOperations.FindHit(intersecs);
        Intersection hit = intersecs.FindHit();
        hit.Should().Be(intsec4);
    }

    [Fact]
    public void TranslatingRay()
    {
        Ray r = new Ray(new Point(1, 2, 3), new Vector(0, 1, 0));
        Matrix m = MathOperations.Translation(3, 4, 5);
        //Ray r2 = MathOperations.TransformRay(r, m);
        Ray r2 = r.Transform(m);
        MathOperations.TuplesEqual(r2.Origin, new Point(4, 6, 8)).Should().BeTrue();
        MathOperations.TuplesEqual(r2.Direction, new Vector(0, 1, 0)).Should().BeTrue();
    }

    [Fact]
    public void ScalingRay()
    {
        Ray r = new Ray(new Point(1, 2, 3), new Vector(0, 1, 0));
        Matrix m = MathOperations.Scaling(2, 3, 4);
        //Ray r2 = MathOperations.TransformRay(r, m);
        Ray r2 = r.Transform(m);
        MathOperations.TuplesEqual(r2.Origin, new Point(2, 6, 12)).Should().BeTrue();
        MathOperations.TuplesEqual(r2.Direction, new Vector(0, 3, 0)).Should().BeTrue();
    }

    [Fact]
    public void RayIntersectingScaledSphere()
    {
        Ray r = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
        Sphere s = new Sphere();
        s.SetTransformation(MathOperations.Scaling(2, 2, 2));
        Intersections intersecs = s.Intersections(r);
        intersecs.list.Count.Should().Be(2);
        intersecs.list[0].T.Should().Be(3);
        intersecs.list[1].T.Should().Be(7);
    }

    [Fact]
    public void NormalVectorOnSphereOnXAxis()
    {
        Sphere s = new Sphere();
        Vector normal = s.Normal(new Point(1, 0, 0));
        MathOperations.TuplesEqual(normal, new Vector(1, 0, 0)).Should().BeTrue();
        normal.Equals(new Vector(1, 0, 0)).Should().BeTrue();
    }

    [Fact]
    public void NormalVectorOnSphereOnYAxis()
    {
        Sphere s = new Sphere();
        Vector normal = s.Normal(new Point(0, 1, 0));
        MathOperations.TuplesEqual(normal, new Vector(0, 1, 0)).Should().BeTrue();
        normal.Equals(new Vector(0, 1, 0)).Should().BeTrue();
    }

    [Fact]
    public void NormalVectorOnSphereOnZAxis()
    {
        Sphere s = new Sphere();
        Vector normal = s.Normal(new Point(0, 0, 1));
        MathOperations.TuplesEqual(normal, new Vector(0, 0, 1)).Should().BeTrue();
        normal.Equals(new Vector(0, 0, 1)).Should().BeTrue();
    }

    [Fact]
    public void NormalVectorOnSphereOnNonAxialPoint()
    {
        Sphere s = new Sphere();
        Vector normal = s.Normal(new Point(Math.Sqrt(3) / 3, Math.Sqrt(3) / 3, Math.Sqrt(3) / 3));
        MathOperations.TuplesEqual(normal, new Vector(Math.Sqrt(3) / 3, Math.Sqrt(3) / 3, Math.Sqrt(3) / 3)).Should().BeTrue();
    }

    [Fact]
    public void NormalVectorIsNormalized()
    {
        Sphere s = new Sphere();
        Vector normal = s.Normal(new Point(Math.Sqrt(3) / 3, Math.Sqrt(3) / 3, Math.Sqrt(3) / 3));
        MathOperations.TuplesEqual(normal, MathOperations.NormalizeVector(normal)).Should().BeTrue();
    }

    [Fact]
    public void ComputingNormalOnTranslatedSphere()
    {
        Sphere s = new Sphere();
        s.SetTransformation(MathOperations.Translation(0, 1, 0));
        Vector normal = s.Normal(new Point(0, 1.70711, -0.70711));
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
        Vector n = s.Normal(new Point(0, Math.Sqrt(2) / 2, -Math.Sqrt(2) / 2));
        MathOperations.TuplesEqual(n, new Vector(0, 0.97014, -0.24254)).Should().BeTrue();
    }

    [Fact]
    public void ReflectingVectorAt45Deg()
    {
        Vector v = new Vector(1, -1, 0);
        Vector n = new Vector(0, 1, 0);
        Vector r = MathOperations.Reflect(v, n);
        MathOperations.TuplesEqual(r, new Vector(1, 1, 0)).Should().BeTrue();
    }

    [Fact]
    public void ReflectingVectorOffSlantedSurface()
    {
        Vector v = new Vector(0, -1, 0);
        Vector n = new Vector(Math.Sqrt(2) / 2, Math.Sqrt(2) / 2, 0);
        Vector r = MathOperations.Reflect(v, n);
        MathOperations.TuplesEqual(r, new Vector(1, 0, 0)).Should().BeTrue();
    }
}
