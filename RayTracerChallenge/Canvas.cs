namespace RayTracerChallenge;
public class Canvas
{
    public int Height, Width;
    //public List<Pixel> pixels = new List<Pixel>();
    public Color[,] Pixels;
    // Create a pixel class that has a color, x and y coordinates

    public Canvas(int height, int width)
    {
        Height = height;
        Width = width;
        Pixels = new Color[height, width];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Pixels[y, x] = new Color();
            }
        }
    }

    public void WritePixelColor(Color color, int y, int x)
    {
        Pixels[y, x] = color;
    }

    public Color GetPixelColor(int y, int x)
    {
        return Pixels[y, x];
    }
}
