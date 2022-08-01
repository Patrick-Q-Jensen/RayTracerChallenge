namespace RayTracerChallenge;

public class Material
{
    public Color Color = new Color();
    private double ambient, diffuse, specular, shininess;

    public double Ambient => ambient;
    public double Diffuse => diffuse;
    public double Specular => specular;
    public double Shininess => shininess;
    

    public Material(double ambient = 0.1, double diffuse = 0.9, double specular = 0.9, double shininess = 200)
    {
        this.ambient = ambient;
        this.diffuse = diffuse;
        this.specular = specular;
        this.shininess = shininess;

    }
}
