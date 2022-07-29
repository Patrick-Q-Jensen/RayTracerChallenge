namespace RayTracerChallenge;

public static class MathOperations {
    const double Epsilon = 0.00001f;
    private readonly static Tuple zeroTuple = new Tuple(0, 0, 0, 0);
    private readonly static Matrix identityMatrix = new Matrix(new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } });

    public static Matrix IdentityMatrix => new Matrix(new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } });

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

    public static bool MatricesEqual(Matrix m1, Matrix m2)
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
                if (FloatingEquals(m1.matrix[y, x], m2.matrix[y, x]) == false) return false; 
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

    public static double MatrixDeterminant(Matrix matrix)
    {
        if(matrix.matrix.GetLength(0) == 2 && matrix.matrix.GetLength(1) == 2)
            return matrix.matrix[0, 0] * matrix.matrix[1, 1] - matrix.matrix[0, 1] * matrix.matrix[1, 0];
        double determinate = 0;
        for (int x = 0; x < matrix.matrix.GetLength(1); x++)
        {
            double cofactor = MatrixCofactor(matrix, 0, x);
            determinate += matrix.matrix[0, x] * cofactor;
        }
        return determinate;
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

    public static double MatrixMinor(Matrix matrix, int row, int column)
    {
        Matrix submatrix = Submatrix(matrix, row, column);
        return MatrixDeterminant(submatrix);
    }

    public static double MatrixCofactor(Matrix matrix, int row, int column)
    {
        double minor = MatrixMinor(matrix, row, column);
        if ((row+column)%2 == 1) return minor*-1;
        return minor;
    }

    public static Matrix InverseMatrix(Matrix matrix)
    {
        Matrix invertedMatrix = new Matrix(new double[matrix.matrix.GetLength(0), matrix.matrix.GetLength(1)]);
        double determinant = MatrixDeterminant(matrix);

        int rowCount = matrix.matrix.GetLength(0);
        int columnCount = matrix.matrix.GetLength(1);

        for (int y = 0; y < rowCount; y++)
        {
            for (int x = 0; x < columnCount; x++)
            {    
                invertedMatrix.matrix[x, y] = MatrixCofactor(matrix, y, x) / determinant;
            }
        }
        return invertedMatrix;
    }

    public static Matrix Translation(double x, double y, double z)
    {
        return new Matrix(new double[4, 4] { { 1,0,0,x }, { 0,1,0,y }, { 0,0,1,z }, { 0,0,0,1 } });        
    }

    public static Matrix Scaling(double x, double y, double z)
    {
        return new Matrix(new double[4, 4] { { x, 0, 0, 0 }, { 0, y, 0, 0}, { 0, 0, z, 0 }, { 0, 0, 0, 1 } });
    }

    public static Matrix Rotation_X(double deg)
    {
        return new Matrix(new double[4, 4] { { 1, 0, 0, 0 }, { 0, Math.Cos(Radians(deg)), -Math.Sin(Radians(deg)), 0 }, { 0, Math.Sin(Radians(deg)), Math.Cos(Radians(deg)), 0 }, { 0, 0, 0, 1 } });
    }

    public static Matrix Rotation_Y(double deg)
    {
        return new Matrix(new double[4, 4] { 
            { Math.Cos(Radians(deg)), 0, Math.Sin(Radians(deg)), 0 }, 
            { 0, 1, 0, 0 }, 
            { -Math.Sin(Radians(deg)), 0, Math.Cos(Radians(deg)), 0 }, 
            { 0, 0, 0, 1 } });
    }

    public static Matrix Rotation_Z(double deg)
    {
        return new Matrix(new double[4, 4] {
            { Math.Cos(Radians(deg)), -Math.Sin(Radians(deg)),0 , 0 },
            { Math.Sin(Radians(deg)), Math.Cos(Radians(deg)), 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 } });
    }

    public static double Radians(double deg)
    {
        return deg / 180 * Math.PI;
    }

    public static double Degrees(double radians)
    {
        return radians * (180 / Math.PI);
    }

    public static Matrix Shear(double xToY, double xToZ, double yToX, double yToZ, double ztoX, double zToY)
    {
        return new Matrix(new double[4, 4] { 
            { 1, xToY, xToZ, 0 }, 
            { yToX, 1, yToZ, 0 }, 
            { ztoX, zToY, 1, 0 }, 
            { 0, 0, 0, 1 } });
    }

    public static Point Position(Ray r, double t)
    {
        Vector v = MultiplyVector(r.Direction, t);
        return AddPointAndVector(r.Origin, v);
    }

    public static List<Intersection> Intersections(Sphere s, Ray r)
    {
        Ray r2 = TransformRay(r, InverseMatrix(s.Transformation));
        Vector sphere_to_ray = SubtractPoints(r2.Origin, new Point(0, 0, 0));
        double a = VectorsDotProduct(r2.Direction, r2.Direction);
        double b = 2 * VectorsDotProduct(r2.Direction, sphere_to_ray);
        double c = VectorsDotProduct(sphere_to_ray, sphere_to_ray) - 1;
        double discriminant = Math.Pow(b, 2) - 4 * a * c;
        //double discriminant = Discriminant(s, r);
        if (discriminant < 0) return new List<Intersection>();
        List<Intersection> intersections = new List<Intersection>();
        intersections.Add(new Intersection((-b - Math.Sqrt(discriminant)) / (2 * a), s));
        intersections.Add(new Intersection((-b + Math.Sqrt(discriminant)) / (2 * a), s));        
        return intersections;

    }

    public static double Discriminant(Sphere s, Ray r)
    {
        Vector sphere_to_ray = SubtractPoints(r.Origin, new Point(0, 0, 0));
        double a = VectorsDotProduct(r.Direction, r.Direction);
        double b = 2 * VectorsDotProduct(r.Direction, sphere_to_ray);
        double c = VectorsDotProduct(sphere_to_ray, sphere_to_ray) - 1;
        double discriminant = Math.Pow(b, 2) - 4 * a * c;
        return discriminant;
    }

    public static Intersection FindHit(List<Intersection> intersections)
    {
        if (intersections == null) return null;
        if (intersections.Count == 0) return null;        
        if (!intersections.Where(x=>x.T > 0).Any()) return null;
                
        return intersections.Where(x=>x.T >= 0.0000d).OrderBy(x=>x.T).ToList().First();    
    }

    public static Ray TransformRay(Ray r, Matrix transformationMatrix)
    {
        return new Ray(MultiplyMatrixWithTuple(transformationMatrix, r.Origin).ToPoint(), 
            MultiplyMatrixWithTuple(transformationMatrix, r.Direction).ToVector());
        //return null;
    }

    public static Vector NormalOnSphere(Sphere s, Point worldPoint)
    {
        Point objectPoint = MultiplyMatrixWithTuple(InverseMatrix(s.Transformation), worldPoint).ToPoint();
        Vector objectNormal = SubtractPoints(objectPoint, new Point(0, 0, 0));
        Vector worldNormal = MultiplyMatrixWithTuple(TransposeMatrix(InverseMatrix(s.Transformation)), objectNormal).ToVector();
        return NormalizeVector(worldNormal);
        //return NormalizeVector(SubtractPoints(p, new Point(0, 0, 0)));
    }

}

