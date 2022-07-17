﻿namespace RayTracerChallenge;

public static class MathOperations {
    const double Epsilon = 0.00001f;
    private readonly static Tuple zeroTuple = new Tuple(0, 0, 0, 0);
    public readonly static Matrix identitryMatrix = new Matrix(new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } });

    public static bool FloatingEquals(double a, double b) {
        if (Math.Abs(a-b) < Epsilon) return true;        
        return false;
    }

    public static bool TuplesEqual(Tuple a, Tuple b) {
        if (FloatingEquals(a.X, b.X) && FloatingEquals(a.Y, b.Y) && FloatingEquals(a.Z, b.Z)) return true;        
        return false;
    }

    public static Point AddPointAndVector(Point a, Vector b) {
        return new Point(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Tuple AddTuples(Tuple a, Tuple b)
    {
        return new Tuple(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    }

    public static Point SubtractVectorFromPoint(Point a, Vector b) {
        return new Point(a.X-b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vector SubtractPoints(Point a, Point b) {
        return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    //public static Vector SubtractVectors(Vector a, Vector b) {
    //    return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    //}

    public static Tuple SubtractTuples(Tuple a, Tuple b) {
        return new Tuple(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    }

    public static Tuple NegateTuple(Tuple t) {      
        return SubtractTuples(zeroTuple, t);
    }

    public static Tuple MultiplyTuple(Tuple t, double multiplier) {
        return new Tuple(t.X * multiplier, t.Y * multiplier, t.Z * multiplier, t.W * multiplier);
    }

    public static Vector MultiplyVector(Vector v, double multiplier)
    {
        return new Vector(v.X * multiplier, v.Y * multiplier, v.Z * multiplier);
    }

    public static Tuple DivideTuple(Tuple t, double divisor) {
        return new Tuple(t.X/divisor, t.Y/divisor, t.Z/divisor, t.W/divisor);
    }

    public static double VectorMagnitude(Vector v) {
        double magnitude = Math.Sqrt((Math.Pow(v.X, 2) + Math.Pow(v.Y, 2) + Math.Pow(v.Z, 2) + Math.Pow(v.W, 2)));
        return magnitude;
    }

    public static Vector NormalizeVector(Vector v) {
        double magnitude = VectorMagnitude(v);
        return new(v.X/magnitude, v.Y/magnitude, v.Z/magnitude);
    }

    public static double VectorsDotProduct(Vector a, Vector b)
    {
        return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z) + (a.W * b.W);
    }

    public static Color MultiplyColors(Color a, Color b)
    {
        return new Color(a.Red * b.Red, a.Green * b.Green, a.Blue * b.Blue);
    }

    public static Vector VectorsCrossProduct(Vector a, Vector b)
    {
        return new Vector(
            a.Y * b.Z - a.Z * b.Y, 
            a.Z * b.X - a.X * b.Z, 
            a.X * b.Y - a.Y * b.X);
    }

    public static bool MatrixesEqual(Matrix m1, Matrix m2)
    {
        if (m1.matrix.LongLength != m2.matrix.LongLength) return false;
        
        int m1RowCount = m1.matrix.GetLength(0);
        int m2RowCount = m2.matrix.GetLength(0);
        if (m1RowCount != m2RowCount) return false;
        
        int m1ColumnCount = m1.matrix.GetLength(1);
        int m2ColumnCount = m2.matrix.GetLength(1);
        if (m1ColumnCount != m2ColumnCount) return false;

        for (int y = 0; y < m1RowCount; y++)
        {
            for (int x = 0; x < m1ColumnCount; x++)
            {
                if (m1.matrix[y, x] != m2.matrix[y, x]) return false; 
            }
        }
        return true;
    }

    public static Matrix MultiplyMatrices(Matrix m1, Matrix m2)
    {
        int m1RowCount = m1.matrix.GetLength(0);
        int m1ColumnCount = m1.matrix.GetLength(1);
        int m2RowCount = m2.matrix.GetLength(0);
        int m2ColumnCount = m2.matrix.GetLength(1);

        
        if (m1ColumnCount != m2RowCount)
            throw new InvalidOperationException
              ("Number of columns of first matrix must equal the number of rows in the second matrix");
        
        Matrix product = new Matrix(new double[m1RowCount, m2ColumnCount]);
                
        for (int matrix1_row = 0; matrix1_row < m1RowCount; matrix1_row++)
        {
            for (int matrix2_col = 0; matrix2_col < m2ColumnCount; matrix2_col++)
            {                
                for (int matrix1_col = 0; matrix1_col < m1ColumnCount; matrix1_col++)
                {
                    product.matrix[matrix1_row, matrix2_col] +=
                      m1.matrix[matrix1_row, matrix1_col] *
                      m2.matrix[matrix1_col, matrix2_col];
                }
            }
        }

        return product;
    }

    public static Tuple MultiplyMatrixWithTuple(Matrix matrix, Tuple tuple)
    {
        double[] tupleMatrix = new double[4] { tuple.X, tuple.Y, tuple.Z, tuple.W };
        double[] product = new double[4];

        for (int y = 0; y < matrix.matrix.GetLength(0); y++)
        {
            for (int x = 0; x < matrix.matrix.GetLength(1); x++)
            {
                product[y] += matrix.matrix[y, x] * tupleMatrix[x];
            }
        }
        return new Tuple(product[0], product[1], product[2], product[3]);
    }

    public static Matrix TransposeMatrix(Matrix matrix)
    {
        int rowCount = matrix.matrix.GetLength(0);
        int columnCount = matrix.matrix.GetLength(1);
        Matrix product = new Matrix(new double[rowCount, columnCount]);

        for (int y = 0; y < rowCount; y++)
        {
            for (int x = 0; x < columnCount; x++)
            {
                product.matrix[x, y] = matrix.matrix[y, x];
            }
        }
        return product;
    }

    public static double CalculateMatrixDeterminant(Matrix matrix)
    {
        return matrix.matrix[0, 0] * matrix.matrix[1, 1] - matrix.matrix[0, 1] * matrix.matrix[1, 0];        
    }

    public static Matrix Submatrix(Matrix  matrix, int row, int column)
    {
        int rowCount = matrix.matrix.GetLength(0);
        int columnCount = matrix.matrix.GetLength(1);
        Matrix product = new Matrix(new double[rowCount - 1, columnCount - 1]);
        int y2 = 0;
        int x2 = 0;
        for (int y = 0; y < rowCount; y++) 
        {
            if (y == row) continue;
            x2 = 0;
            for (int x = 0; x < columnCount; x++) 
            {
                if (x == column) continue;
                product.matrix[y2,x2] = matrix.matrix[y, x];
                x2++;
            }
            y2++;
        }
        return product;
    }

}

