namespace RayTracerChallenge;

public class Material :  IEquatable<Material>
{
    public Color Color = new Color(1,1,1);
    //private double ambient, diffuse, specular, shininess;
    public Pattern Pattern;
    public double Ambient;
    public double Diffuse;
    public double Specular;
    public double Shininess;
    public double Reflective;

    public Material(double ambient = 0.1, double diffuse = 0.9, double specular = 0.9, double shininess = 200, double reflective = 0)
    {
        Ambient = ambient;
        Diffuse = diffuse;
        Specular = specular;
        Shininess = shininess;
        Reflective = reflective;
    }
    public Material(Color color, double ambient = 0.1, double diffuse = 0.9, double specular = 0.9, double shininess = 200)
    {
        Ambient = ambient;
        Diffuse = diffuse;
        Specular = specular;
        Shininess = shininess;
        Color = color;
    }

    public bool Equals(Material? other)
    {
        if (other == null)
        {
            return false;
        }
        return Ambient == other.Ambient 
            && Diffuse == other.Diffuse
            && Specular == other.Specular
            && Shininess == other.Shininess
            && Color.Equals(other.Color);
    }
}
