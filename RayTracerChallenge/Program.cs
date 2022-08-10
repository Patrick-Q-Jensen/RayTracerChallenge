namespace RayTracerChallenge;

internal class Program {
    static void Main(string[] args) {

        //CastRayTest();
        //CastRayTest1();
        Chapter7();
    }

    private static void CastRayTest1()
    {
        Point ray_origin = new Point(0, 0, -5);
        double wall_z = 10d;
        double wallSize = 7d;
        int canvasPixels = 200;
        double pixel_size = wallSize / canvasPixels;
        double half = wallSize / 2;
        Canvas canvas = new Canvas(canvasPixels, canvasPixels);
        Color color = new Color(1, 0, 0);
        Sphere s = new Sphere();

        for (int y = 0; y < canvasPixels - 1; y++)
        {
            double world_y = half - pixel_size * y;
            for (int x = 0; x < canvasPixels - 1; x++)
            {
                double world_x = -half + pixel_size * x;
                Point position = new Point(world_x, world_y, wall_z);
                Ray r = new Ray(ray_origin, MathOperations.NormalizeVector(MathOperations.SubtractPoints(position, ray_origin)));
                Intersections intersecs = s.Intersections(r);
                //Intersections intersecs = MathOperations.SphereIntersections(s, r);

                Intersection hit = MathOperations.FindHit(intersecs);
                if (hit == null)
                {
                    continue;
                }
                canvas.WritePixelColor(color, x, y);
            }
        }
        canvas.SavePPMToFile(canvas.ConvertToPPM(), @"C:\Users\Patrick Quitzau Jens\Documents\CastRayTest1.ppm");
    }

    private static void CastRayTest()
    {
        Point ray_origin = new(0, 0, -5);
        double wall_z = 10d;
        double wallSize = 7d;
        int canvasPixels = 512;
        double pixel_size = wallSize / canvasPixels;
        double half = wallSize / 2;
        Canvas canvas = new(canvasPixels, canvasPixels);
        Sphere s = new();
        s.Material.Color = new Color(1, 0.2, 1);
        Point lightPosition = new(-10, 10, -10);
        Color lightColor = new(1, 1, 1);
        PointLight light = new(lightPosition, lightColor);

        for (int y = 0; y < canvasPixels-1; y++) {
            double world_y = half - pixel_size * y;
            for (int x = 0; x < canvasPixels-1; x++) {
                
                double world_x = -half + pixel_size * x;
                Point position = new(world_x, world_y, wall_z);
                Ray r = new(ray_origin, position.Subtract(ray_origin).Normalize());
                //Intersections intersecs = r.Intersections(s);
                Intersections intersecs = s.Intersections(r);
                Intersection hit = intersecs.FindHit();
                if (hit == null)
                {
                    continue;
                }
                Point intersectionPoint = r.Position(hit.T);
                Vector normal = hit.Shape.Normal(intersectionPoint);
                Vector eye = r.Direction.Negate();
                Color color = MathOperations.Lighting(hit.Shape.Material, intersectionPoint, light, eye, normal);
                canvas.WritePixelColor(color, x, y);
            }
        }
        canvas.SavePPMToFile(canvas.ConvertToPPM(), @"C:\Users\Patrick Quitzau Jens\Documents\CastRayTest.ppm");
    }

    private static void LaunchProjectile()
    {
        Canvas canvas = new Canvas(550, 900);
        Vector projectileStartingVelocity = MathOperations.NormalizeVector(new Vector(1, 2.5, 0));
        projectileStartingVelocity = MathOperations.MultiplyVector(projectileStartingVelocity, 15.25);
        Projectile proj = new Projectile(new Point(0, 1, 0), projectileStartingVelocity);
        Vector gravity = new Vector(0, -0.2, 0);
        Vector wind = new Vector(-0.1, 0, 0);
        Environment env = new Environment(gravity, wind);
        Color projColor = new Color(1, 0, 0);

        int tickCount = 0;
        while (proj.Position.Y > 0.00f)
        {
            canvas.WritePixelColor(projColor, canvas.Height - (int)Math.Round(proj.Position.Y), (int)Math.Round(proj.Position.X));
            proj = Tick(proj, env);
            tickCount++;

            //Console.WriteLine($"Projectile position: X:[{proj.Position.X}] Y:[{proj.Position.Y}] Z:[{proj.Position.Z}]");
        }
        canvas.SavePPMToFile(canvas.ConvertToPPM(), @"C:\Users\Patrick Quitzau Jens\Documents\ProjTest.ppm");
        Console.WriteLine($"Tick count: {tickCount}");
    }

    private static Projectile Tick(Projectile proj, Environment env) {

        Point position = MathOperations.AddPointAndVector(proj.Position, proj.Velocity);
        Vector gravityAndWind = MathOperations.AddTuples(env.Gravity, env.Wind).ToVector();
        Vector velocity = MathOperations.AddTuples(proj.Velocity, gravityAndWind).ToVector();        
        return new Projectile(position, velocity);
    }

    private static void Chapter7()
    {
        World world = new World();

        Sphere floor = new Sphere();
        floor.Transformation = floor.Transformation.Scale(10, 0.01, 10);
        floor.Material.Color = new Color(1, 0.9, 0.9);
        floor.Material.Specular = 0;

        Sphere leftWall = new Sphere();
        leftWall.Transformation = leftWall.Transformation
            .Translate(0, 0, 5)
            .Rotate(Axis.Y, -Math.PI / 4)
            .Rotate(Axis.X, Math.PI / 2)
            .Scale(10, 0.01, 10);
        leftWall.Material = floor.Material;

        Sphere rightWall = new Sphere();
        rightWall.Transformation = rightWall.Transformation
            .Translate(0, 0, 5)
            .Rotate(Axis.Y, Math.PI / 4)
            .Rotate(Axis.X, Math.PI / 2)
            .Scale(10, 0.01, 10);
        rightWall.Material = floor.Material;

        Sphere middleSphere = new Sphere();
        middleSphere.Transformation = middleSphere.Transformation.Translate(-0.5, 1, 0.5);
        middleSphere.Material.Color = new Color(0.1, 1, 0.5);
        middleSphere.Material.Diffuse = 0.7;
        middleSphere.Material.Specular = 0.3;

        Sphere rightSphere = new Sphere();
        rightSphere.Transformation = rightSphere.Transformation.Translate(1.5, 0.5, -0.5).Scale(0.5, 0.5, 0.5);
        rightSphere.Material.Color = new Color(0.5, 1, 0.1);
        rightSphere.Material.Diffuse = 0.7;
        rightSphere.Material.Specular = 0.3;

        Sphere leftSphere = new Sphere();
        leftSphere.Transformation = leftSphere.Transformation.Translate(-1.5, 0.33, -0.75).Scale(0.33, 0.33, 0.33);
        leftSphere.Material.Color = new Color(1, 0.8, 0.1);
        leftSphere.Material.Diffuse = 0.7;
        leftSphere.Material.Specular = 0.3;

        world.PointLight = new PointLight(new Point(10, 10, -10), new Color(1, 1, 1));
        
        Camera camera = new Camera(600, 600, Math.PI / 3);
        //camera.Tranformation = camera.Tranformation.
        camera.Tranformation = MathOperations.ViewTransform(
            new Point(0, 2.5, -8),
            new Point(0, 1, 0),
            new Vector(0, 1, 0));
        world.Shapes.Clear();
        world.Shapes.Add(floor);
        world.Shapes.Add(leftWall);
        world.Shapes.Add(rightWall);
        world.Shapes.Add(middleSphere);
        world.Shapes.Add(rightSphere);
        world.Shapes.Add(leftSphere);
        world.Shapes.Add(middleSphere);

        Canvas image = camera.Render(world);
        image.SavePPMToFile(image.ConvertToPPM(), @"C:\Users\Patrick Quitzau Jens\Documents\CastRayTest1.ppm");
    }
}



// See https://aka.ms/new-console-template for more information

