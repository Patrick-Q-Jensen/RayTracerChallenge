namespace RayTracerChallenge;

public class Material
{
    public Color Color = new Color(1,1,1);
    //private double ambient, diffuse, specular, shininess;

    public double Ambient;
    public double Diffuse;
    public double Specular;
    public double Shininess;


    public Material(double ambient = 0.1, double diffuse = 0.9, double specular = 0.9, double shininess = 200)
    {
        Ambient = ambient;
        Diffuse = diffuse;
        Specular = specular;
        Shininess = shininess;
    }
    public Material(Color color, double ambient = 0.1, double diffuse = 0.9, double specular = 0.9, double shininess = 200)
    {
        Ambient = ambient;
        Diffuse = diffuse;
        Specular = specular;
        Shininess = shininess;
        Color = color;
    }
}
