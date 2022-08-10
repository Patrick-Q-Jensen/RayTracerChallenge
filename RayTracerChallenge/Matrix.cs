namespace RayTracerChallenge;

public class Matrix
{
    public double[,] matrix;
    private int rowCount;
    private int columnCount;

    //public double[,] Mtrx => matrix;

    public Matrix(int rows, int columns)
    {
        rowCount = rows;
        columnCount = columns;
        matrix = new double[rows, columns];
    }

    public Matrix(double[,] matrix)
    {
        this.matrix = matrix;
    }

    public void SetMatrixValue(int row, int column, double value)
    {
        if (row < 0 || column < 0) return;
        if (row >= rowCount || column >= columnCount) return;
        matrix[row, column] = value;
    }

    public Matrix Translate(double x, double y, double z) {
        return this * MathOperations.Translation(x, y, z);
    }

    public Matrix Scale(double x, double y, double z)
    {
        return this * MathOperations.Scaling(x, y, z);
    }

    public Matrix Rotate(Axis axis, double radians)
    {
        switch (axis)
        {
            case Axis.X:
                return this * MathOperations.Rotation_X(MathOperations.Degrees(radians));
            case Axis.Y:
                return this * MathOperations.Rotation_Y(MathOperations.Degrees(radians));
            case Axis.Z:
                return this * MathOperations.Rotation_Z(MathOperations.Degrees(radians));
            default:
                return this;
        }
    }

    public bool Equals(Matrix m)
    {
        return MathOperations.MatricesEqual(this, m);
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        return MathOperations.MultiplyMatrices(a, b);
    }

    public static Tuple operator *(Matrix a, Tuple b)
    {
        return MathOperations.MultiplyMatrixWithTuple(a, b);
    }

    public Matrix Inverse()
    {
        return MathOperations.InverseMatrix(this);
    }

}
