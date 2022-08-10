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
            MathOperations.TuplesEqual(material.Color, new Color(1, 1, 1)).Should().BeTrue();
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
            MathOperations.TuplesEqual(result, new Color(1.9, 1.9, 1.9)).Should().BeTrue();
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
            MathOperations.TuplesEqual(result, new Color(1, 1, 1)).Should().BeTrue();
        }

        [Fact]
        public void LightingWithEyeOppositeSurfaceOffset45Deg()
        {
            Material m = new Material();
            Point position = new Point(0, 0, 0);

            Vector eye = new Vector(0, 0, -1);
            Vector normalV = new Vector(0, 0, -1);
            PointLight light = new PointLight(new Point(0, 10, -10), new Color(1, 1, 1));
            Color result = MathOperations.Lighting(m, position, light, eye, normalV);
            MathOperations.TuplesEqual(result, new Color(0.7364, 0.7364, 0.7364)).Should().BeTrue();
        }

        [Fact]
        public void LightingWithEyeInPathOfRelectionVector()
        {
            Material m = new Material();
            Point position = new Point(0, 0, 0);

            Vector eye = new Vector(0, -Math.Sqrt(2) / 2, -Math.Sqrt(2) / 2);
            Vector normalV = new Vector(0, 0, -1);
            PointLight light = new PointLight(new Point(0, 10, -10), new Color(1, 1, 1));
            Color result = MathOperations.Lighting(m, position, light, eye, normalV);
            MathOperations.TuplesEqual(result, new Color(1.6364, 1.6364, 1.6364)).Should().BeTrue();
        }

        [Fact]
        public void LightingWithLightBehindTheSurface()
        {
            Material m = new();
            Point position = new(0, 0, 0);
            Vector eye = new(0, 0, -1);
            Vector normalV = new(0, 0, -1);
            PointLight light = new(new Point(0,0,10),new Color(1,1,1));
            Color result = MathOperations.Lighting(m, position, light, eye, normalV);
            MathOperations.TuplesEqual(result, new Color(0.1, 0.1, 0.1)).Should().BeTrue();
        }

        [Fact]
        public void ShadingAnIntersection()
        {
            World w = new();
            Ray r = new(new Point(0, 0, -5), new Vector(0, 0, 1));
            Shape s = w.Shapes.First();
            Intersection i = new(4, s);
            IntersectionComputation ic = new(i, r);
            Color c = MathOperations.ShadeHit(w, ic);
            c.Equals(new Color(0.38066, 0.47583, 0.2855)).Should().BeTrue();
        }

        [Fact]
        public void ShadingAnIntersectionFromInside()
        {
            World w = new World();
            w.PointLight = new PointLight(new Point(0, 0.25, 0), new Color(1, 1, 1));
            Ray r = new Ray(new Point(0,0,0), new Vector(0, 0, 1));
            Shape s = w.Shapes[1];
            Intersection i = new Intersection(0.5, s);
            IntersectionComputation ic = new IntersectionComputation(i, r);
            Color c = MathOperations.ShadeHit(w, ic);
            c.Equals(new Color(0.90498, 0.90498, 0.90498)).Should().BeTrue();
        }

        [Fact]
        public void ColorWhenRayMisses()
        {
            World w = new World();
            Ray r = new Ray(new Point(0,0,-5),new Vector(0, 1, 0));
            Color c = MathOperations.ColorAt(w, r);
            c.Equals(new Color(0, 0, 0)).Should().BeTrue();
        }

        [Fact]
        public void ColorWhenRayHits()
        {
            World w = new World();
            Ray r = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
            Color c = MathOperations.ColorAt(w, r);
            c.Equals(new Color(0.38066, 0.47583, 0.2855)).Should().BeTrue();
        }

        [Fact]
        public void TheColorWithAnIntersectionBehindTheRay()
        {
            World w = new World();
            Shape outer = w.Shapes[0];
            outer.Material.Ambient = 1;
            Shape inner = w.Shapes[1];
            inner.Material.Ambient = 1;
            Ray r = new Ray(new Point(0, 0, 0.75), new Vector(0, 0, -1));
            Color c = MathOperations.ColorAt(w, r);
            c.Equals(inner.Material.Color).Should().BeTrue();
        }

        [Fact]
        public void LightingWithSurfaceInShadow()
        {
            Material m = new Material();
            Point position = new Point(0, 0, 0);

            Vector eyeV = new Vector(0, 0, -1);
            Vector normalV = new Vector(0, 0, -1);
            PointLight light = new PointLight(new Point(0, 0, -10), new Color(1, 1, 1));
            bool inShadow = true;
            Color c = MathOperations.Lighting(m, position, light, eyeV, normalV, inShadow);
            c.Equals(new Color(0.1, 0.1, 0.1)).Should().BeTrue();
        }

        [Fact]
        public void NoShadowWhenNothingIsCollinearWithPointAndLight()
        {
            World w = new World();
            Point p = new Point(0,10,0);
            w.IsShadowed(p).Should().BeFalse();
        }

        [Fact]
        public void ShadowWhenAnObjectIsBetweenPointAndLight()
        {
            World w = new World();
            Point p = new Point(10, -10, 10);
            w.IsShadowed(p).Should().BeTrue();
        }

        [Fact]
        public void NoShadowWhenAnObjectIsBehindTheLight()
        {
            World w = new World();
            Point p = new Point(-20, 20, -20);
            w.IsShadowed(p).Should().BeFalse();
        }

        [Fact]
        public void NoShadowWhenAnObjectIsBehindThePoint()
        {
            World w = new World();
            Point p = new Point(-2, 2, -2);
            w.IsShadowed(p).Should().BeFalse();
        }

        [Fact]
        public void ShadeHitReturnsTrueWhenIntersectionIsInShadow()
        {
            World w = new World();
            w.Shapes.Clear();
            w.PointLight = new PointLight(new Point(0, 0, -10), new Color(1, 1, 1));
            Sphere s1 = new Sphere();
            w.Shapes.Add(s1);
            Sphere s2 = new Sphere();
            s2.Transformation = s2.Transformation.Translate(0, 0, 10);
            w.Shapes.Add(s2);
            Ray r = new Ray(new Point(0, 0, 5), new Vector(0, 0, 1));
            Intersection i = new Intersection(4, s2);
            IntersectionComputation ic = new IntersectionComputation(i, r);
            Color c = MathOperations.ShadeHit(w, ic);
            c.Equals(new Color(0.1, 0.1, 0.1));
        }
    }
}
