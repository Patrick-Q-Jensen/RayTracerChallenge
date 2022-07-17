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
}
