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
        MathOperations.MatricesEqual(matrix1, matrix2).Should().BeTrue();
        matrix2 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 1 } });
        MathOperations.MatricesEqual(matrix1, matrix2).Should().BeFalse();
        matrix2 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 } });
        MathOperations.MatricesEqual(matrix1, matrix2).Should().BeFalse();
    }

    [Fact]
    public void MultiplyingMatrices()
    {
        Matrix matrix1 = new Matrix(new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } });
        Matrix matrix2 = new Matrix(new double[,] { { -2, 1, 2, 3 }, { 3, 2, 1, -1 }, { 4, 3, 6, 5 }, { 1, 2, 7, 8 } });
        Matrix expectedResult = new Matrix(new double[,] { { 20, 22, 50, 48 }, { 44, 54, 114, 108 }, { 40, 58, 110, 102 }, {16, 26, 46, 42 } });
        Matrix actualResult = MathOperations.MultiplyMatrices(matrix1, matrix2);
        MathOperations.MatricesEqual(expectedResult, actualResult).Should().BeTrue();
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
        Matrix matrix2 = MathOperations.MultiplyMatrices(matrix1, MathOperations.IdentityMatrix);
        MathOperations.MatricesEqual(matrix1, matrix2).Should().BeTrue();
    }

    [Fact]
    public void TransposingMatrix()
    {
        Matrix matrix1 = new Matrix(new double[,] { { 0, 9, 3, 0 }, { 9, 8, 0, 8 }, { 1, 8, 5, 3 }, { 0, 0, 5, 8 } });
        Matrix expectedProduct = new Matrix(new double[,] { { 0, 9, 1, 0 }, { 9, 8, 8, 0 }, { 3, 0, 5, 5 }, { 0, 8, 3, 8 } });
        Matrix actualProduct = MathOperations.TransposeMatrix(matrix1);
        MathOperations.MatricesEqual(expectedProduct, actualProduct).Should().BeTrue();
    }

    [Fact]
    public void DeterminingDeterminantOf2x2Matrix()
    {
        Matrix matrix = new Matrix(new double[2, 2] { { 1, 5 }, { -3, 2 } });
        MathOperations.MatrixDeterminant(matrix).Should().Be(17);
    }

    [Fact]
    public void FindSubmatrixOf3x3Matrix()
    {
        Matrix matrix3x3 = new Matrix(new double[3, 3] { { 1, 5, 0 }, { -3, 2, 7 }, { 0, 6, -3 } });
        Matrix matrix2x2 = new Matrix(new double[2, 2] { { -3, 2 }, { 0, 6 } });
        Matrix product = MathOperations.Submatrix(matrix3x3, 0, 2);
        MathOperations.MatricesEqual(product, matrix2x2).Should().BeTrue();
    }

    [Fact]
    public void FindSubmatrixOf4x4Matrix()
    {
        Matrix matrix4x4 = new Matrix(new double[4, 4] { { -6, 1, 1, 6 }, { -8, 5, 8, 6 }, { -1, 0, 8, 2 }, { -7, 1, -1, 1 } });
        Matrix matrix3x3 = new Matrix(new double[3, 3] { { -6, 1, 6 }, { -8, 8, 6 }, { -7, -1, 1 } });
        Matrix product = MathOperations.Submatrix(matrix4x4, 2, 1);
        MathOperations.MatricesEqual(matrix3x3, product).Should().BeTrue();
    }

    [Fact]
    public void CaculatingMinorOf3x3Matrix()
    {
        Matrix matrix3x3 = new Matrix(new double[3, 3] { { 3, 5, 0 }, { 2, -1, -7 }, { 6, -1, 5 } });
        Matrix subMatrix = MathOperations.Submatrix(matrix3x3, 1, 0);
        double determinant = MathOperations.MatrixDeterminant(subMatrix);
        determinant.Should().Be(25);
        MathOperations.MatrixMinor(matrix3x3, 1, 0).Should().Be(determinant);
    }

    [Fact]
    public void CalculatingMatrixCofactor()
    {
        Matrix matrix3x3 = new Matrix(new double[3, 3] { { 3, 5, 0 }, { 2, -1, -7 }, { 6, -1, 5 } });
        MathOperations.MatrixMinor(matrix3x3, 0, 0).Should().Be(-12);
        MathOperations.MatrixCofactor(matrix3x3, 0, 0).Should().Be(-12);
        MathOperations.MatrixMinor(matrix3x3, 1, 0).Should().Be(25);
        MathOperations.MatrixCofactor(matrix3x3, 1, 0).Should().Be(-25);
    }

    [Fact]
    public void CalculatingDeterminantOf3x3Matrix()
    {
        Matrix matrix3x3 = new Matrix(new double[3, 3] { { 1, 2, 6 }, { -5, 8, -4 }, { 2, 6, 4 } });
        MathOperations.MatrixCofactor(matrix3x3, 0, 0).Should().Be(56);
        MathOperations.MatrixCofactor(matrix3x3, 0, 1).Should().Be(12);
        MathOperations.MatrixCofactor(matrix3x3, 0, 2).Should().Be(-46);
        MathOperations.MatrixDeterminant(matrix3x3).Should().Be(-196);
    }

    [Fact]
    public void CalculatingDeterminantOf4x4Matrix()
    {
        Matrix matrix4x4 = new Matrix(new double[4, 4] { { -2, -8, 3, 5 }, { -3, 1, 7, 3 }, { 1, 2, -9, 6 }, { -6, 7, 7, -9 } });
        MathOperations.MatrixDeterminant(matrix4x4).Should().Be(-4071);
        MathOperations.MatrixCofactor(matrix4x4, 0, 0).Should().Be(690);
        MathOperations.MatrixCofactor(matrix4x4, 0, 1).Should().Be(447);
        MathOperations.MatrixCofactor(matrix4x4, 0, 2).Should().Be(210);
        MathOperations.MatrixCofactor(matrix4x4, 0, 3).Should().Be(51);   
    }

    [Fact]
    public void Matrix4x4IsInvertible()
    {
        Matrix matrix4x4 = new Matrix(new double[4, 4] { { 6, 4, 4, 4 }, { 5, 5, 7, 6 }, { 4, -9, 3, -7 }, { 9, 1, 7, -6 } });
        MathOperations.MatrixDeterminant(matrix4x4).Should().Be(-2120);
    }

    [Fact]
    public void Matrix4x4IsNotInvertible()
    {
        Matrix matrix4x4 = new Matrix(new double[4, 4] { { -4, 2, -2, -3 }, { 9, 6, 2, 6 }, { 0, -5, 1, -5 }, { 0, 0, 0, 0 } });
        MathOperations.MatrixDeterminant(matrix4x4).Should().Be(0);
    }

    [Fact]
    public void Matrix4x4Inverse()
    {
        Matrix matrix4x4 = new Matrix(new double[4, 4] { { -5, 2, 6, -8 }, { 1, -5, 1, 8 }, { 7, 7, -6, -7 }, { 1, -3, 7, 4 } });
        Matrix expectedInversedMatrix = new Matrix(new double[4, 4] { 
            { 0.21805, 0.45113, 0.24060, -0.04511 }, 
            { -0.80827, -1.45677, -0.44361, 0.52068 }, 
            { -0.07895, -0.22368, -0.05263, 0.19737 }, 
            { -0.52256, -0.81391, -0.30075, 0.30639 } });
        Matrix inversedMatrix = MathOperations.InverseMatrix(matrix4x4);

        MathOperations.MatrixDeterminant(matrix4x4).Should().Be(532);
        MathOperations.MatrixCofactor(matrix4x4, 2, 3).Should().Be(-160);
        double t = -160d / 532d;
        
        inversedMatrix.matrix[3, 2].Should().Be(t);
        MathOperations.MatrixCofactor(matrix4x4, 3, 2).Should().Be(105);
        inversedMatrix.matrix[2, 3].Should().Be(105d / 532d);
        MathOperations.MatricesEqual(expectedInversedMatrix, inversedMatrix).Should().BeTrue();
    }

    [Fact]
    public void MatrixInvertion1()
    {
        Matrix matrix = new Matrix(new double[4, 4] { 
            { 8, -5, 9, 2 }, 
            { 7, 5, 6, 1 }, 
            { -6, 0, 9, 6 }, 
            { -3, 0, -9, -4 } });
        Matrix expectedInversedMatrix = new Matrix(new double[4, 4] { 
            { -0.15385, -0.15385, -0.28205, -0.53846 }, 
            { -0.07692, 0.12308, 0.02564, 0.03077 }, 
            { 0.35897, 0.35897, 0.43590, 0.92308 }, 
            { -0.69231, -0.69231, -0.76923, -1.92308 } });
        Matrix inversedMatrix = MathOperations.InverseMatrix(matrix);
        MathOperations.MatricesEqual(expectedInversedMatrix, inversedMatrix).Should().BeTrue();
    }

    [Fact]
    public void MatrixInvertion2()
    {
        Matrix matrix = new Matrix(new double[4, 4] { { 9, 3, 0, 9 }, { -5, -2, -6, -3 }, { -4, 9, 6, 4 }, { -7, 6, 6, 2 } });
        Matrix expectedInversedMatrix = new Matrix(new double[4, 4] { { -0.04074, -0.07778, 0.14444, -0.22222 }, { -0.07778, 0.03333, 0.36667, -0.33333 }, { -0.02901, -0.14630, -0.10926, 0.12963 }, { 0.17778, 0.06667, -0.26667, 0.33333 } });
        Matrix invertedMatrix = MathOperations.InverseMatrix(matrix);
        MathOperations.MatricesEqual(expectedInversedMatrix, invertedMatrix).Should().BeTrue();
    }

    [Fact]
    public void MatrixInvertion3()
    {
        Matrix matrix1 = new Matrix(new double[4, 4] { { 3, -9, 7, 3 }, { 3, -8, 2, -9 }, { -4, 4, 4, 1 }, { -6, 5, -1, 1 } });
        Matrix matrix2 = new Matrix(new double[4, 4] { { 8, 2, 2, 2 }, { 3, -1, 7, 0 }, { 7, 0, 5, 4 }, { 6, -2, 0, 5 } });
        Matrix matrix3 = MathOperations.MultiplyMatrices(matrix1, matrix2);
        Matrix inverseMatrix2 = MathOperations.InverseMatrix(matrix2);
        Matrix product = MathOperations.MultiplyMatrices(matrix3, inverseMatrix2);
        MathOperations.MatricesEqual(matrix1, product).Should().BeTrue();
    }

}
