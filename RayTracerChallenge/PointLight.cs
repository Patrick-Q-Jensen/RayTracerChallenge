namespace RayTracerChallenge;

public class PointLight
{
    public Point Position;
    public Color Intensity;

    public PointLight(Point position, Color intensity)
    {
        Position = position;
        Intensity = intensity;
    }
}
