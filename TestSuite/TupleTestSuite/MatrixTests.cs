namespace RayTracerChallengeTestSuite;

public class MatrixTests
{
    [Fact]
    public void MatrixConstructor()
    {
        Matrix matrix = new Matrix(4, 4);

        matrix.SetMatrixValue(0, 0, 1);
        matrix.SetMatrixValue(1, 0, 5.5);
        matrix.SetMatrixValue(2, 0, 9);
        matrix.SetMatrixValue(3, 0, 13.5);

        matrix.SetMatrixValue(0, 1, 2);
        matrix.SetMatrixValue(1, 1, 6.5);
        matrix.SetMatrixValue(2, 1, 10);
        matrix.SetMatrixValue(3, 1, 14.5);

        matrix.SetMatrixValue(0, 2, 3);
        matrix.SetMatrixValue(1, 2, 7.5);
        matrix.SetMatrixValue(2, 2, 11);
        matrix.SetMatrixValue(3, 2, 15.5);

        matrix.SetMatrixValue(0, 3, 4);
        matrix.SetMatrixValue(1, 3, 8.5);
        matrix.SetMatrixValue(2, 3, 12);
        matrix.SetMatrixValue(3, 3, 16.5);

        matrix.matrix[0, 0].Should().Be(1);
        matrix.matrix[0, 3].Should().Be(4);
        matrix.matrix[1, 0].Should().Be(5.5);
        matrix.matrix[1, 2].Should().Be(7.5);
        matrix.matrix[2, 2].Should().Be(11);
        matrix.matrix[3, 0].Should().Be(13.5);
        matrix.matrix[3, 2].Should().Be(15.5);
    }

    [Fact]
    public void MatrixConstructor2x2()
    {
        Matrix matrix = new Matrix(new double[,] { { -3, 5 }, { 1, -2 } });
        matrix.matrix[0, 0].Should().Be(-3);
        matrix.matrix[1, 1].Should().Be(-2);
        matrix.matrix[1, 0].Should().Be(1);
        matrix.matrix[1, 1].Should().Be(-2);
    }

    [Fact]
    public void MatrixConstructor3x3()
    {
        Matrix matrix = new Matrix(new double[,] { { -3, 5, 0 }, { 1, -2, -7 }, { 0, 1, 1 } });
        matrix.matrix[0, 0].Should().Be(-3);
        matrix.matrix[1, 1].Should().Be(-2);
        matrix.matrix[1, 0].Should().Be(1);
        matrix.matrix[2, 2].Should().Be(1);
    }

    [Fact]
    public void MatrixEquality()
    {
        Matrix matrix1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } });
        Matrix matrix2 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } });
        MathOperations.MatrixesEqual(matrix1, matrix2).Should().BeTrue();
        matrix2 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 1 } });
        MathOperations.MatrixesEqual(matrix1, matrix2).Should().BeFalse();
        matrix2 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 } });
        MathOperations.MatrixesEqual(matrix1, matrix2).Should().BeFalse();
    }

    [Fact]
    public void MultiplyingMatrices()
    {
        Matrix matrix1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } });
        Matrix matrix2 = new Matrix(new double[,] { { -2, 1, 2, 3 }, { 3, 2, 1, -1 }, { 4, 3, 6, 5 }, { 1, 2, 7, 8 } });
        Matrix expectedResult = new Matrix(new double[,] { { 20, 22, 50, 48 }, { 44, 54, 114, 108 }, { 40, 58, 110, 102 }, {16, 26, 46, 42 } });
        Matrix actualResult = MathOperations.MultiplyMatrices(matrix1, matrix2);
        MathOperations.MatrixesEqual(expectedResult, actualResult).Should().BeTrue();
    }

    [Fact]
    public void MutliplyingMatrixWithTuple()
    {
        Matrix matrix1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 2, 4, 4, 2 }, { 8, 6, 4, 1 }, { 0, 0, 0, 1 } });
        Tuple t = new Tuple(1, 2, 3, 1);
        Tuple expectedTuple = new(18, 24, 33, 1);
        Tuple actualTuple = MathOperations.MultiplyMatrixWithTuple(matrix1, t);
        MathOperations.TuplesEqual(expectedTuple, actualTuple).Should().BeTrue();
    }

    [Fact]
    public void MultiplyingMatrixWithIdentityMatrix()
    {
        Matrix matrix1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 2, 4, 4, 2 }, { 8, 6, 4, 1 }, { 0, 0, 0, 1 } });
        Matrix matrix2 = MathOperations.MultiplyMatrices(matrix1, MathOperations.identitryMatrix);
        MathOperations.MatrixesEqual(matrix1, matrix2).Should().BeTrue();
    }

    [Fact]
    public void TransposingMatrix()
    {
        Matrix matrix1 = new Matrix(new double[,] { { 0, 9, 3, 0 }, { 9, 8, 0, 8 }, { 1, 8, 5, 3 }, { 0, 0, 5, 8 } });
        Matrix expectedProduct = new Matrix(new double[,] { { 0, 9, 1, 0 }, { 9, 8, 8, 0 }, { 3, 0, 5, 5 }, { 0, 8, 3, 8 } });
        Matrix actualProduct = MathOperations.TransposeMatrix(matrix1);
        MathOperations.MatrixesEqual(expectedProduct, actualProduct).Should().BeTrue();
    }

    [Fact]
    public void DeterminingDeterminantOf2x2Matrix()
    {
        Matrix matrix = new Matrix(new double[2, 2] { { 1, 5 }, { -3, 2 } });
        MathOperations.CalculateMatrixDeterminant(matrix).Should().Be(17);
    }

    [Fact]
    public void FindSubmatrixOf3x3Matrix()
    {
        Matrix matrix3x3 = new Matrix(new double[3, 3] { { 1, 5, 0 }, { -3, 2, 7 }, { 0, 6, -3 } });
        Matrix matrix2x2 = new Matrix(new double[2, 2] { { -3, 2 }, { 0, 6 } });
        Matrix product = MathOperations.Submatrix(matrix3x3, 0, 2);
        MathOperations.MatrixesEqual(product, matrix2x2).Should().BeTrue();
    }

    [Fact]
    public void FindSubmatrixOf4x4Matrix()
    {
        Matrix matrix4x4 = new Matrix(new double[4, 4] { { -6, 1, 1, 6 }, { -8, 5, 8, 6 }, { -1, 0, 8, 2 }, { -7, 1, -1, 1 } });
        Matrix matrix3x3 = new Matrix(new double[3, 3] { { -6, 1, 6 }, { -8, 8, 6 }, { -7, -1, 1 } });
        Matrix product = MathOperations.Submatrix(matrix4x4, 2, 1);
        MathOperations.MatrixesEqual(matrix3x3, product).Should().BeTrue();
    }

}
