namespace RayTracerChallengeTestSuite;

public class MathOperationTests {

    [Fact]
    public void FloatingEqualsTest() {
        double a = 1;
        double b = 2;
        Assert.False(MathOperations.FloatingEquals(a, b));
        b = 1;
        Assert.True(MathOperations.FloatingEquals(a, b));
        a = 1.000001d;
        Assert.True(MathOperations.FloatingEquals(a, b));
        a = 1.001d;
        Assert.False(MathOperations.FloatingEquals(a, b));
    }

    [Fact]
    public void TupleEqualsTest() {
        Point a = new(1.2d, 1.3d, 1.4d);
        Vector b = new(1.3d, 1.3d, 1.4d);
        Assert.False(MathOperations.TuplesEqual(a, b));
        b.X = 1.2d;
        Assert.True(MathOperations.TuplesEqual(a, b));
    }

    [Fact]
    public void AddPointAndVectorTest()
    {
        Point a = new(2.5d, -2.5d, 0d);
        Vector b = new(-5d, 5d, 2d);
        Point c = new(-2.5d, 2.5d, 2d);

        Assert.True(MathOperations.TuplesEqual(c, MathOperations.AddPointAndVector(a, b)));        
    }

    [Fact]
    public void AddVectorsTest()
    {
        Vector a = new(2.5d, -2.5d, 0d);
        Vector b = new(-5d, 5d, 2d);
        Vector c = new(-2.5d, 2.5d, 2d);

        Assert.True(MathOperations.TuplesEqual(c, MathOperations.AddTuples(a, b)));
    }

    [Fact]
    public void AddColorsTest()
    {
        Color a = new(0.5, 0.2, 0.1);
        Color b = new(0.5, 0.3, 0.8);
        Color c = new(1, 0.5, 0.9);

        MathOperations.TuplesEqual(MathOperations.AddTuples(a, b), c).Should().BeTrue();
    }

    [Fact]
    public void SubtractPointsTest()
    {
        Point a = new(2.5d, -2.5d, 4d);
        Point b = new(5d, -5d, 2d);

        Vector c = new(-2.5d, 2.5d, 2d);

        Assert.True(MathOperations.TuplesEqual(c, MathOperations.SubtractPoints(a, b)));
    }

    [Fact]
    public void SubtractVectorFromPointTest()
    {
        Point a = new(2.5d, -2.5d, 4d);
        Vector b = new(5d, -5d, 2d);
        Point c = new(-2.5d, 2.5d, 2d);

        Assert.True(MathOperations.TuplesEqual(c, MathOperations.SubtractVectorFromPoint(a, b)));
    }

    [Fact]
    public void SubtractVectorsTest()
    {
        Vector a = new(2.5d, -2.5d, 4d);
        Vector b = new(5d, -5d, 2d);
        Vector c = new(-2.5d, 2.5d, 2d);

        Assert.True(MathOperations.TuplesEqual(c, MathOperations.SubtractTuples(a, b)));
    }

    [Fact]
    public void SubtractColorsTest()
    {
        Vector a = new(0.5, 0.2, 1);
        Vector b = new(0.2, 0.2, 0.1);
        Vector c = new(0.3, 0, 0.9);

        Assert.True(MathOperations.TuplesEqual(c, MathOperations.SubtractTuples(a, b)));
    }

    [Fact]
    public void NegateVectorTest()
    {
        Vector a = new(2.5, -2.5, 4);
        Vector b = new(-2.5, 2.5, -4);
        

        Assert.True(MathOperations.TuplesEqual(b, MathOperations.NegateTuple(a)));
    }

    [Fact]
    public void NegateTupleTest()
    {
        Tuple a = new(2.5d, -2.5d, 4d, 2d);
        Tuple expectedNegatedTuple = new(-2.5, 2.5, -4, -2);
        Tuple actualNegatedTuple = MathOperations.NegateTuple(a);
        MathOperations.TuplesEqual(expectedNegatedTuple, actualNegatedTuple).Should().BeTrue();       
    }

    [Fact]
    public void MultiplyTupleScalar()
    {
        Tuple a = new(2.5, -2.5, 4, 2);
        double scalarValue = 3.5d;
        Tuple expectedMultipliedTuple = new(8.75, -8.75, 14, 7);
        Tuple actualMultipliedTuple = MathOperations.MultiplyTuple(a, scalarValue);
        MathOperations.TuplesEqual(expectedMultipliedTuple, actualMultipliedTuple).Should().BeTrue();
    }

    [Fact]
    public void MultiplyColorScalar()
    {
        Color a = new(0.1, 0.3, 0.5);
        double scalarValue = 2d;
        Color expectedMultipliedColor = new(0.2, 0.6, 1);
        Tuple actualMultipliedTuple = MathOperations.MultiplyTuple(a, scalarValue);
        MathOperations.TuplesEqual(expectedMultipliedColor, actualMultipliedTuple).Should().BeTrue();
    }


    [Fact]
    public void MultiplyTupleFraction()
    {
        Tuple a = new(2.5, -2.5, 4, 2);
        double scalarValue = 0.5d;
        Tuple expectedMultipliedTuple = new(1.25, -1.25, 2, 1);
        Tuple actualMultipliedTuple = MathOperations.MultiplyTuple(a, scalarValue);
        MathOperations.TuplesEqual(expectedMultipliedTuple, actualMultipliedTuple).Should().BeTrue();
    }

    [Fact]
    public void DivideTuple()
    {
        Tuple a = new(2.5, -2.5, 4, 2);
        double divisor = 2;
        Tuple expectedMultipliedTuple = new(1.25f, -1.25f, 2f, 1f);
        Tuple actualMultipliedTuple = MathOperations.DivideTuple(a, divisor);
        MathOperations.TuplesEqual(expectedMultipliedTuple, actualMultipliedTuple).Should().BeTrue();
    }

    [Fact]
    public void MagnitudeVectorTest()
    {
        Vector v = new(1, 0, 0);
        MathOperations.VectorMagnitude(v).Should().Be(1);
        v = new(0, 1, 0);
        MathOperations.VectorMagnitude(v).Should().Be(1);
        v = new(0, 0, 1);
        MathOperations.VectorMagnitude(v).Should().Be(1);
        v = new(1, 2, 3);
        MathOperations.VectorMagnitude(v).Should().Be(Math.Sqrt(14));
        v = new(-1, -2, -3);
        MathOperations.VectorMagnitude(v).Should().Be(Math.Sqrt(14));
    }

    [Fact]
    public void NormalizingVector()
    {
        Vector v1 = new Vector(4, 0, 0);
        Vector expectedNormalizedVector = new Vector(1, 0, 0);
        Vector actualNormalizedVector = MathOperations.NormalizeVector(v1);
        MathOperations.TuplesEqual(expectedNormalizedVector, actualNormalizedVector).Should().BeTrue();
    }

    [Fact]
    public void DotProductVector()
    {
        Vector v1 = new(1,2,3);
        Vector v2 = new(2,3,4);
        MathOperations.VectorsDotProduct(v1, v2).Should().Be(20);
    }

    [Fact]
    public void CrossProductVector()
    {
        Vector v1 = new(1, 2, 3);
        Vector v2 = new(2, 3, 4);
        Vector expectedCross1 = new(-1, 2, -1);
        Vector expectedCross2 = new(1, -2, 1);
        Vector actualCross1 = MathOperations.VectorsCrossProduct(v1, v2);
        Vector actualCross2 = MathOperations.VectorsCrossProduct(v2, v1);
        MathOperations.TuplesEqual(expectedCross1, actualCross1).Should().BeTrue();
        MathOperations.TuplesEqual(expectedCross2, actualCross2).Should().BeTrue();
    }
}

