namespace RayTracerChallengeTestSuite;

public class MathOperationTests {
    [Fact]
    public void FloatingEqualsTest() {
        float a = 1;
        float b = 2;
        Assert.False(MathOperations.FloatingEquals(a, b));
        b = 1;
        Assert.True(MathOperations.FloatingEquals(a, b));
        a = 1.000001f;
        Assert.True(MathOperations.FloatingEquals(a, b));
        a = 1.001f;
        Assert.False(MathOperations.FloatingEquals(a, b));
    }

    [Fact]
    public void TupleEqualsTest() {
        Point a = new(1.2f, 1.3f, 1.4f);
        Vector b = new(1.3f, 1.3f, 1.4f);
        Assert.False(MathOperations.TuplesEqual(a, b));
        b.X = 1.2f;
        Assert.True(MathOperations.TuplesEqual(a, b));
    }

    [Fact]
    public void AddPointAndVectorTest()
    {
        Point a = new(2.5f, -2.5f, 0f);
        Vector b = new(-5f, 5f, 2f);
        Point c = new(-2.5f, 2.5f, 2f);

        Assert.True(MathOperations.TuplesEqual(c, MathOperations.AddPointAndVector(a, b)));        
    }

    [Fact]
    public void AddVectorsTest()
    {
        Vector a = new(2.5f, -2.5f, 0f);
        Vector b = new(-5f, 5f, 2f);
        Vector c = new(-2.5f, 2.5f, 2f);

        Assert.True(MathOperations.TuplesEqual(c, MathOperations.AddVectors(a, b)));
    }

    [Fact]
    public void SubtractPointsTest()
    {
        Point a = new(2.5f, -2.5f, 4f);
        Point b = new(5f, -5f, 2f);

        Vector c = new(-2.5f, 2.5f, 2f);

        Assert.True(MathOperations.TuplesEqual(c, MathOperations.SubtractPoints(a, b)));
    }

    [Fact]
    public void SubtractVectorFromPointTest()
    {
        Point a = new(2.5f, -2.5f, 4f);
        Vector b = new(5f, -5f, 2f);
        Point c = new(-2.5f, 2.5f, 2f);

        Assert.True(MathOperations.TuplesEqual(c, MathOperations.SubtractVectorFromPoint(a, b)));
    }

    [Fact]
    public void SubtractVectorsTest()
    {
        Vector a = new(2.5f, -2.5f, 4f);
        Vector b = new(5f, -5f, 2f);
        Vector c = new(-2.5f, 2.5f, 2f);

        Assert.True(MathOperations.TuplesEqual(c, MathOperations.SubtractVectors(a, b)));
    }

    [Fact]
    public void NegateVectorTest()
    {
        Vector a = new(2.5f, -2.5f, 4f);
        Vector b = new(-2.5f, 2.5f, -4f);
        

        Assert.True(MathOperations.TuplesEqual(b, MathOperations.NegateTuple(a)));
    }

    [Fact]
    public void NegateTupleTest()
    {
        Tuple a = new(2.5f, -2.5f, 4f, 2f);
        Tuple expectedNegatedTuple = new(-2.5f, 2.5f, -4f, -2f);
        Tuple actualNegatedTuple = MathOperations.NegateTuple(a);
        MathOperations.TuplesEqual(expectedNegatedTuple, actualNegatedTuple).Should().BeTrue();       
    }

    [Fact]
    public void MultiplyTupleScalar()
    {
        Tuple a = new(2.5f, -2.5f, 4f, 2f);
        float scalarValue = 3.5f;
        Tuple expectedMultipliedTuple = new(8.75f, -8.75f, 14f, 7f);
        Tuple actualMultipliedTuple = MathOperations.MultiplyTuple(a, scalarValue);
        MathOperations.TuplesEqual(expectedMultipliedTuple, actualMultipliedTuple).Should().BeTrue();
    }

    [Fact]
    public void MultiplyTupleFraction()
    {
        Tuple a = new(2.5f, -2.5f, 4f, 2f);
        float scalarValue = 0.5f;
        Tuple expectedMultipliedTuple = new(1.25f, -1.25f, 2f, 1f);
        Tuple actualMultipliedTuple = MathOperations.MultiplyTuple(a, scalarValue);
        MathOperations.TuplesEqual(expectedMultipliedTuple, actualMultipliedTuple).Should().BeTrue();
    }


}

