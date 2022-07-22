namespace RayTracerChallengeTestSuite;

public class TransformationTests
{
    [Fact]
    public void TranslationMatrix()
    {
        Matrix transform = MathOperations.Translation(5, -3, 2);
        Point p = new Point(-3, 4, 5);
        Point expectedProduct = new Point(2, 1, 7);
        Point p2 = MathOperations.MultiplyMatrixWithTuple(transform, p).ToPoint();
        MathOperations.TuplesEqual(expectedProduct, p2);
    }

    [Fact]
    public void InverseOfTranslationMatrix()
    {
        Matrix transform = MathOperations.Translation(5, -3, 2);
        Matrix inverse = MathOperations.InverseMatrix(transform);
        Point p = new Point(-3, 4, 5);
        Point expectedProduct = new Point(-8, 7, 3);
        Point product = MathOperations.MultiplyMatrixWithTuple(inverse, p).ToPoint();
        MathOperations.TuplesEqual(expectedProduct, product).Should().BeTrue();
    }

    [Fact]
    public void TranslationOfVector()
    {
        Matrix transform = MathOperations.Translation(5, -3, 2);
        Vector v = new Vector(-3, 4, 5);
        Vector product = MathOperations.MultiplyMatrixWithTuple(transform, v).ToVector();
        MathOperations.TuplesEqual(v, product).Should().BeTrue();
    }

    [Fact]
    public void ScalingAPoint()
    {
        Matrix transform = MathOperations.Scaling(2, 3, 4);
        Point p = new Point(-4, 6, 8);
        Point expecteProduct = new Point(-8, 18, 32);
        Point product = MathOperations.MultiplyMatrixWithTuple(transform, p).ToPoint();
        MathOperations.TuplesEqual(expecteProduct, product).Should().BeTrue();
    }

    [Fact]
    public void ScalingAVector()
    {
        Matrix transform = MathOperations.Scaling(2,3,4);
        Vector v = new Vector(-4, 6, 8);
        Vector expectedProduct = new Vector(-8, 18, 32);
        Vector product = MathOperations.MultiplyMatrixWithTuple(transform, v).ToVector();
        MathOperations.TuplesEqual(expectedProduct, product);
    }

    [Fact]
    public void InverseScalingVector()
    {
        Matrix transform = MathOperations.Scaling(2, 3, 4);
        Matrix inverseTransform = MathOperations.InverseMatrix(transform);
        Vector v = new Vector(-4, 6, 8);
        Vector expectedProduct = new Vector(-2, 2, 2);
        Vector product = MathOperations.MultiplyMatrixWithTuple(inverseTransform, v).ToVector();
        MathOperations.TuplesEqual(expectedProduct, product).Should().BeTrue();
    }

    [Fact]
    public void ReflectionOfAPoint()
    {
        Matrix transform = MathOperations.Scaling(-1, 1, 1);
        Point p = new Point(2, 3, 4);
        Point expectedProduct = new Point(-2, 3, 4);
        Point product = MathOperations.MultiplyMatrixWithTuple(transform, p).ToPoint();
        MathOperations.TuplesEqual(expectedProduct, product).Should().BeTrue();
    }

    [Fact]
    public void RotationOfPointAroundXAxis()
    {
        Point p = new Point(0, 1, 0);
        Matrix half_quarter = MathOperations.Rotation_X(45);
        Matrix full_quarter = MathOperations.Rotation_X(90);
        double t = Math.Sqrt(2)/2;

        Point expectedHalfQuarterProduct = new Point(0, t, t);
        Point halfQuarterProduct = MathOperations.MultiplyMatrixWithTuple(half_quarter, p).ToPoint();
        Point expectedFullQuarterProduct = new Point(0, 0, 1);
        Point fullQuarterProduct = MathOperations.MultiplyMatrixWithTuple(full_quarter, p).ToPoint();
        MathOperations.TuplesEqual(expectedHalfQuarterProduct, halfQuarterProduct).Should().BeTrue();
        MathOperations.TuplesEqual(expectedFullQuarterProduct, fullQuarterProduct).Should().BeTrue();

    }

    [Fact]
    public void InverseRotationOfPointAroundXAxis()
    {
        Point p = new Point(0, 1, 0);
        Matrix half_quarter = MathOperations.Rotation_X(45);
        Matrix inv_Half_Quarter = MathOperations.InverseMatrix(half_quarter);
        Point expectedProduct = new Point(0, Math.Sqrt(2d / 2d), -Math.Sqrt(2d / 2d));
        Point product = MathOperations.MultiplyMatrixWithTuple(inv_Half_Quarter, p).ToPoint();
        MathOperations.TuplesEqual(expectedProduct, product);
    }

    [Fact]
    public void RotationOfPointAroundYAxis()
    {
        Point p = new Point(0,0,1);
        Matrix half_quarter = MathOperations.Rotation_Y(45);
        Matrix full_quarter = MathOperations.Rotation_Y(90);

        Point expectedHalfQuarterProduct = new Point(Math.Sqrt(2) / 2, 0, Math.Sqrt(2) / 2);
        Point expectedFullQuarterProduct = new Point(Math.Sqrt(2) / 2, 0, Math.Sqrt(2) / 2);

        Point halfQuarterProduct = MathOperations.MultiplyMatrixWithTuple(half_quarter, p).ToPoint();
        Point fullQuarterProduct = MathOperations.MultiplyMatrixWithTuple(full_quarter, p).ToPoint();

        MathOperations.TuplesEqual(expectedHalfQuarterProduct, halfQuarterProduct);
        MathOperations.TuplesEqual(expectedFullQuarterProduct, fullQuarterProduct);
    }

    [Fact]
    public void RotationOfPointAroundZAxis()
    {
        Point p = new Point(0, 0, 1);
        Matrix half_quarter = MathOperations.Rotation_Z(45);
        Matrix full_quarter = MathOperations.Rotation_Z(90);

        Point expectedHalfQuarterProduct = new Point(-(Math.Sqrt(2) / 2), Math.Sqrt(2) / 2, 0);
        Point expectedFullQuarterProduct = new Point(-1, 0, 0);

        Point halfQuarterProduct = MathOperations.MultiplyMatrixWithTuple(half_quarter, p).ToPoint();
        Point fullQuarterProduct = MathOperations.MultiplyMatrixWithTuple(full_quarter, p).ToPoint();

    }

    [Fact]
    public void ShearingPoint()
    {
        Point p = new Point(2, 3, 4);
        Point expectedProduct = new Point(5, 3, 4);
        Matrix shear = MathOperations.Shear(1, 0, 0, 0, 0, 0);
        Point product = MathOperations.MultiplyMatrixWithTuple(shear,p).ToPoint();
        MathOperations.TuplesEqual(expectedProduct, product);

        shear = MathOperations.Shear(0, 1, 0, 0, 0, 0);
        expectedProduct = new Point(6, 3, 4);
        product = MathOperations.MultiplyMatrixWithTuple(shear,p).ToPoint();
        MathOperations.TuplesEqual(expectedProduct, product);

        shear = MathOperations.Shear(0, 0, 1, 0, 0, 0);
        expectedProduct = new Point(2, 5, 4);
        product = MathOperations.MultiplyMatrixWithTuple(shear, p).ToPoint();
        MathOperations.TuplesEqual(expectedProduct, product);

        shear = MathOperations.Shear(0, 0, 0, 1, 0, 0);
        expectedProduct = new Point(2, 7, 4);
        product = MathOperations.MultiplyMatrixWithTuple(shear, p).ToPoint();
        MathOperations.TuplesEqual(expectedProduct, product);

        shear = MathOperations.Shear(0, 0, 0, 0, 1, 0);
        expectedProduct = new Point(2, 3, 6);
        product = MathOperations.MultiplyMatrixWithTuple(shear, p).ToPoint();
        MathOperations.TuplesEqual(expectedProduct, product);

        shear = MathOperations.Shear(0, 0, 0, 0, 0, 1);
        expectedProduct = new Point(2, 3, 7);
        product = MathOperations.MultiplyMatrixWithTuple(shear, p).ToPoint();
        MathOperations.TuplesEqual(expectedProduct, product);
    }

    [Fact]
    public void TransformationSequence()
    {
        Point p = new Point(1, 0, 1);
        Matrix a = MathOperations.Rotation_X(90);
        Matrix b = MathOperations.Scaling(5, 5, 5);
        Matrix c = MathOperations.Translation(10, 5, 7);

        Point p2 = MathOperations.MultiplyMatrixWithTuple(a, p).ToPoint();
        Point expectedP2 = new Point(1, -1, 0);
        MathOperations.TuplesEqual(expectedP2, p2).Should().BeTrue();

        Point p3 = MathOperations.MultiplyMatrixWithTuple(b, p2).ToPoint();
        Point expectedP3 = new Point(5, -5, 0);
        MathOperations.TuplesEqual(expectedP3, p3).Should().BeTrue();

        Point p4 = MathOperations.MultiplyMatrixWithTuple(c, p3).ToPoint();
        Point expectedP4 = new Point(15, 0, 7);
        MathOperations.TuplesEqual(expectedP4, p4).Should().BeTrue();
    }

    [Fact]
    public void TransformationReverseSequence() {
        Point p = new Point(1, 0, 1);
        Matrix a = MathOperations.Rotation_X(90);
        Matrix b = MathOperations.Scaling(5, 5, 5);
        Matrix c = MathOperations.Translation(10, 5, 7);
        Matrix t = MathOperations.MultiplyMatrices(c, MathOperations.MultiplyMatrices(a, b));
        Point product = MathOperations.MultiplyMatrixWithTuple(t, p).ToPoint();
        Point expectedProduct = new Point(15, 0, 7);
        MathOperations.TuplesEqual(expectedProduct, product).Should().BeTrue();
    }

}
