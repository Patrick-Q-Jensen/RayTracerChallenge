using System.Text;

namespace RayTracerChallenge;
public class Canvas
{
    public int Height, Width;
    public Color[,] Pixels;
    // Create a pixel class that has a color, x and y coordinates

    public Canvas(int height, int width, Color? initialColor = null)
    {

        Height = height;
        Width = width;
        Pixels = new Color[height, width];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Pixels[y, x] = initialColor ?? new Color();
            }
        }
    }

    public void WritePixelColor(Color color, int y, int x)
    {
        if (y >= Height || y < 0 ||  x >= Width || x < 0)
        {
            return;
        }
        Pixels[y, x] = color;
    }

    public Color GetPixelColor(int y, int x)
    {
        return Pixels[y, x];
    }

    public string ConvertToPPM()
    {
        
        StringBuilder sb = new StringBuilder(BuildHeader());
        for (int y = 0; y < Height; y++)
        {
            string newLine = "";
            for (int x = 0; x < Width; x++)
            {
                newLine += $"{ConvertColorValue(GetPixelColor(y, x).Red)} {ConvertColorValue(GetPixelColor(y, x).Green)} {ConvertColorValue(GetPixelColor(y, x).Blue)} ";
                if (newLine.Length >= 60)
                {
                    newLine = newLine.Remove(newLine.Length - 1);
                    newLine += "\n";
                    sb.Append(newLine);
                    newLine = "";
                }
            }

            if (newLine.Length == 0) continue;
            newLine = newLine.Remove(newLine.Length - 1);
            newLine += "\n";
            sb.Append(newLine);
        }
        return sb.ToString();
    }

    public void SavePPMToFile(string PPM, string filePath)
    {
        File.WriteAllText(filePath, PPM);
    }

    private int ConvertColorValue(double colorValue)
    {
        int min1 = 0;
        int max1 = 1;
        int range1 = max1 - min1;

        int min2 = 0;
        int max2 = 255;
        int range2 = max2 - min2;

        double val2 = (colorValue - min1) * range2 / range1 + min2;

        if (val2 < 0)
        {
            val2 = 0;
        }
        if (val2 > 255)
        {
            val2 = 255;
        }
        return (int)Math.Round(val2);
    }

    //private int ConvertColorValue(double colorValue)
    //{
    //    //int min1 = 0;
    //    //int max1 = 1;
    //    //int range1 = max1 - min1;

    //    //int min2 = 0;
    //    //int max2 = 255;
    //    //int range2 = max2 - min2;

    //    //double val2 = (colorValue - min1) * range2 / range1 + min2;

    //    if (colorValue < 0)
    //    {
    //        colorValue = 0;
    //    }
    //    if (colorValue > 255)
    //    {
    //        colorValue = 255;
    //    }
    //    return (int)Math.Round(colorValue);
    //}

    private string BuildHeader()
    {
        return $"P3\n{Width} {Height}\n255\n";
    }
}
