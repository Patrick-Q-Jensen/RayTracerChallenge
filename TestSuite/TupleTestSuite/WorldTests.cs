namespace RayTracerChallengeTestSuite;

public class WorldTests
{
    [Fact]
    public void DefaultWorld() {
        PointLight light = new PointLight(new Point(-10, 10, -10), new Color(1, 1, 1));
        Sphere s1 = new Sphere(new Material(diffuse: 0.7, specular: 0.2, color: new Color(0.8, 1.0, 0.6)));
        Sphere s2 = new Sphere();
        s2.SetTransformation(MathOperations.Scaling(0.5, 0.5, 0.5));
        World w = new World();
        MathOperations.TuplesEqual(light.Position, w.PointLight.Position).Should().BeTrue();
        MathOperations.TuplesEqual(light.Intensity, w.PointLight.Intensity).Should().BeTrue();
        w.Shapes[0].Material.Shininess.Should().Be(s1.Material.Shininess);
        w.Shapes[0].Material.Specular.Should().Be(s1.Material.Specular);
        w.Shapes[0].Material.Diffuse.Should().Be(s1.Material.Diffuse);
        w.Shapes[0].Material.Ambient.Should().Be(s1.Material.Ambient);
        MathOperations.TuplesEqual(w.Shapes[0].Material.Color, s1.Material.Color).Should().BeTrue();
        MathOperations.MatricesEqual(w.Shapes[0].Transformation, s1.Transformation).Should().BeTrue();

        w.Shapes[1].Material.Shininess.Should().Be(s2.Material.Shininess);
        w.Shapes[1].Material.Specular.Should().Be(s2.Material.Specular);
        w.Shapes[1].Material.Diffuse.Should().Be(s2.Material.Diffuse);
        w.Shapes[1].Material.Ambient.Should().Be(s2.Material.Ambient);
        MathOperations.TuplesEqual(w.Shapes[1].Material.Color, s2.Material.Color).Should().BeTrue();
        MathOperations.MatricesEqual(w.Shapes[1].Transformation, s2.Transformation).Should().BeTrue();

    }

    [Fact]
    public void IntersectWorldWithRay()
    {
        World w = new World();
        Ray r = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
        Intersections intersecs = w.IntersectRay(r);
        intersecs.list.Count.Should().Be(4);
        intersecs.list[0].T.Should().Be(4);
        intersecs.list[1].T.Should().Be(4.5);
        intersecs.list[2].T.Should().Be(5.5);
        intersecs.list[3].T.Should().Be(6);
    }

    [Fact]
    public void PrecomputingStateOfIntersection()
    {
        Ray r = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
        Shape s = new Sphere();
        Intersection i = new Intersection(4, s);
        IntersectionComputation intsecComp = new IntersectionComputation(i, r);
        intsecComp.T.Should().Be(i.T);
        intsecComp.Shape.Should().Be(s);
        MathOperations.TuplesEqual(intsecComp.Point, new Point(0, 0, -1));
        MathOperations.TuplesEqual(intsecComp.EyeV, new Vector(0, 0, -1));
        MathOperations.TuplesEqual(intsecComp.NormalV, new Vector(0, 0, -1));
    }

    [Fact]
    public void IntersectionOccursOutside()
    {
        Ray r = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
        Shape s = new Sphere();
        Intersection i = new Intersection(4, s);
        IntersectionComputation ic = new IntersectionComputation(i, r);
        ic.Inside.Should().BeFalse();
    }

    [Fact]
    public void IntersectionOccursOnInside()
    {
        Ray r = new Ray(new Point(0,0,0), new Vector(0,0,1));
        Shape s = new Sphere();
        Intersection i = new Intersection(1, s);
        IntersectionComputation ic = new IntersectionComputation(i, r);
        ic.Point.Equals(new Point(0,0,1)).Should().BeTrue();
        ic.EyeV.Equals(new Vector(0, 0, -1)).Should().BeTrue();
        ic.Inside.Should().BeTrue();
        ic.NormalV.Equals(new Vector(0, 0, -1)).Should().BeTrue();
    }

    [Fact]
    public void TransformationMatrixForDefaultOrientation()
    {
        Point from = new Point(0, 0, 0);
        Point to = new Point(0, 0, -1);
        Vector up = new Vector(0, 1, 0);
        Matrix t = MathOperations.ViewTransform(from, to, up);
        t.Equals(MathOperations.IdentityMatrix);
    }

    [Fact]
    public void ViewTransformationLookinInPositiveZDirection()
    {
        Point from = new Point(0, 0, 0);
        Point to = new Point(0, 0, 1);
        Vector up = new Vector(0, 1, 0);
        Matrix t = MathOperations.ViewTransform(from, to, up);
        t.Equals(MathOperations.Scaling(-1, 1, -1)).Should().BeTrue();
    }

    [Fact]
    public void ViewTransformationMovesWorld()
    {
        Point from = new Point(0, 0, 8);
        Point to = new Point(0, 0, 0);
        Vector up = new Vector(0, 1, 0);
        Matrix t = MathOperations.ViewTransform(from, to, up);
        t.Equals(MathOperations.Translation(0, 0, -8)).Should().BeTrue();
    }

    [Fact]
    public void ArbitraryViewTransform()
    {
        Point from = new Point(1, 3, 2);
        Point to = new Point(4, -2, 8);
        Vector up = new Vector(1, 1, 0);
        Matrix t = MathOperations.ViewTransform(from, to, up);
        t.Equals(new Matrix(new double[4,4] { 
            { -0.50709, 0.50709, 0.67612, -2.36643 }, 
            { 0.76772, 0.60609, 0.12122, -2.82843 }, 
            { -0.35857, 0.59761, -0.71714, 0.00000 }, 
            { 0.00000, 0.00000, 0.00000, 1.00000 } })).Should().BeTrue();
    }


}
