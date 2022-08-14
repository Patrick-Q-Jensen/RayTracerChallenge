namespace RayTracerChallenge;

public class Camera
{
    public double Hsize;
    public double Vsize;
    public double FieldOfView;
    public Matrix Tranformation = MathOperations.IdentityMatrix;
    public double PixelSize;
    public double HalfView;
    public double Aspect;
    public double HalfWidth;
    public double HalfHeight;

    public Camera(double hsize, double vsize, double fieldOfView)
    {
        Hsize = hsize;
        Vsize = vsize;
        FieldOfView = fieldOfView;
        HalfView = Math.Tan(fieldOfView / 2);
        Aspect = hsize / vsize;
        SetHeightAndWidth();
        PixelSize = (HalfWidth * 2) / hsize;
    }

    private void SetHeightAndWidth()
    {
        if (Aspect >= 1)
        {
            HalfWidth = HalfView;
            HalfHeight = HalfView / Aspect;
        }
        else
        {
            HalfWidth = HalfView * Aspect;
            HalfHeight = HalfView;
        }
    }

    public Ray RayForPixel(int x, int y)
    {
        double xOffSet = (x + 0.5) * PixelSize;
        double yOffSet = (y + 0.5) * PixelSize;

        double worldX = HalfWidth - xOffSet;
        double worldY = HalfHeight - yOffSet;

        Point pixel = (Tranformation.Inverse() * new Point(worldX, worldY, -1)).ToPoint();
        Point origin = (Tranformation.Inverse() * new Point(0, 0, 0)).ToPoint();
        Vector direction = (pixel - origin).Normalize();
        return new Ray(origin, direction);
    }

    public Canvas Render(World w)
    {
        Canvas image = new Canvas((int)Math.Round(Hsize), (int)Math.Round(Vsize));
        for (int y = 0; y < Vsize-1; y++)
        {
            for (int x = 0; x < Hsize-1; x++)
            {
                Ray r = RayForPixel(x, y);
                Color c = w.TraceRayColor(r);
                image.WritePixelColor(c, y, x);
            }
        }
        return image;
    }

    public Canvas ThreadedRender(World w)
    {
        Canvas image = new Canvas((int)Math.Round(Hsize), (int)Math.Round(Vsize));
        Parallel.For(0, (int)Vsize, vsize => {
            for (int hsize = 0; hsize < Hsize - 1; hsize++)
            {
                Ray r = RayForPixel(hsize, vsize);
                Color c = w.TraceRayColor(r);
                image.WritePixelColor(c, vsize, hsize);
            }
        });
        return image;
    }
}
