namespace RayTracerChallengeTestSuite
{
    public class LightingTests
    {
        [Fact]
        public void PointLightConstructor()
        {
            Color intensity = new Color(1, 1, 1);
            Point position = new Point(0, 0, 0);
            PointLight light = new PointLight(position, intensity);
            MathOperations.TuplesEqual(position, light.Position).Should().BeTrue();
            MathOperations.TuplesEqual(intensity, light.Intensity).Should().BeTrue();
        }

        [Fact]
        public void MaterialConstructor()
        {
            Material material = new Material();
            material.Ambient.Should().Be(0.1);
            material.Diffuse.Should().Be(0.9);
            material.Specular.Should().Be(0.9);
            material.Shininess.Should().Be(200);
            MathOperations.TuplesEqual(material.Color, new Color(1, 1, 1));
        }

        [Fact]
        public void SphereDefaultMaterial()
        {
            Sphere s = new Sphere();
            Material material = new Material();
            s.Material.Ambient.Should().Be(material.Ambient);
            s.Material.Diffuse.Should().Be(material.Diffuse);
            s.Material.Shininess.Should().Be(material.Shininess);
            s.Material.Specular.Should().Be(material.Specular);
        }

        [Fact]
        public void AssignMaterialToSphere()
        {
            Sphere s = new Sphere();
            Material material = new Material(ambient:1);
            s.Material = material;
            s.Material.Ambient.Should().Be(material.Ambient);
            s.Material.Diffuse.Should().Be(material.Diffuse);
            s.Material.Shininess.Should().Be(material.Shininess);
            s.Material.Specular.Should().Be(material.Specular);
        }

        [Fact]
        public void LightingWithEyeBetweenLightAndSurface()
        {
            Material m = new Material();
            Point position = new Point(0, 0, 0);
            Vector eye = new Vector(0, 0, -1);
            Vector normalV = new Vector(0, 0, -1);
            PointLight light = new PointLight(new Point(0,0,-10), new Color(1,1,1));
            Color result = MathOperations.Lighting(m, position, light, eye, normalV);
            MathOperations.TuplesEqual(result, new Color(1.9, 1.9, 1.9));
        }

        [Fact]
        public void LightingWithEyeBetweenLightAndSurfaceOffset45Deg()
        {
            Material m = new Material();
            Point position = new Point(0, 0, 0);
            Vector eye = new Vector(0, Math.Sqrt(2)/2, -Math.Sqrt(2) / 2);
            Vector normalV = new Vector(0, 0, -1);
            PointLight light = new PointLight(new Point(0, 0, -10), new Color(1, 1, 1));
            Color result = MathOperations.Lighting(m, position, light, eye, normalV);
            MathOperations.TuplesEqual(result, new Color(0.7364, 0.7364, 0.7364));
        }

        [Fact]
        public void LightingWithEyeInPathOfRelectionVector()
        {
            Material m = new Material();
            Point position = new Point(0, 0, 0);
            Vector eye = new Vector(0, -Math.Sqrt(2) / 2, -Math.Sqrt(2) / 2);
            Vector normalV = new Vector(0, 0, -1);
            PointLight light = new PointLight(new Point(0, 0, -10), new Color(1, 1, 1));
            Color result = MathOperations.Lighting(m, position, light, eye, normalV);
            MathOperations.TuplesEqual(result, new Color(1.6364, 1.6364, 1.6364));
        }

        [Fact]
        public void LightingWithLightBehindTheSurface()
        {
            Material m = new Material();
            Point position = new Point(0, 0, 0);
            Vector eye = new Vector(0, 0, -1);
            Vector normalV = new Vector(0, 0, -1);
            PointLight light = new PointLight(new Point(0,0,10),new Color(1,1,1));
            Color result = MathOperations.Lighting(m, position, light, eye, normalV);
            MathOperations.TuplesEqual(result, new Color(0.1, 0.1, 0.1));
        }
    }
}
