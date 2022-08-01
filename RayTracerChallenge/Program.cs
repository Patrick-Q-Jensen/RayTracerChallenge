namespace RayTracerChallenge;

internal class Program {
    static void Main(string[] args) {

        CastRayTest();
        CastRayTest1();
    }

    private static void DrawClock()
    {
        Canvas canvas = new Canvas(500, 500);
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
        //s.Material.Color = new Color(1, 0.2, 1);
        //Point lightPosition = new Point(-10, 10, -10);
        //Color lightColor = new Color(1, 1, 1);
        //PointLight light = new PointLight(lightPosition, lightColor);
        //Matrix transformation = MathOperations.MultiplyMatrices(MathOperations.Shear(0,0,0,0,1,0),MathOperations.Scaling(1, 0.5, 1));
        //s.SetTransformation(transformation);

        for (int y = 0; y < canvasPixels - 1; y++)
        {
            double world_y = half - pixel_size * y;
            for (int x = 0; x < canvasPixels - 1; x++)
            {
                double world_x = -half + pixel_size * x;
                Point position = new Point(world_x, world_y, wall_z);
                Ray r = new Ray(ray_origin, MathOperations.NormalizeVector(MathOperations.SubtractPoints(position, ray_origin)));
                Intersections intersecs = MathOperations.Intersections(s, r);

                Intersection hit = MathOperations.FindHit(intersecs);
                if (hit == null)
                {
                    continue;
                }
                //Point point = MathOperations.Position(r, hit.T);
                //Vector normal = MathOperations.NormalOnSphere((Sphere)hit.IntersectionObject, point);
                //Vector eye = MathOperations.NegateTuple(r.Direction).ToVector();
                //Color color = MathOperations.Lighting(hit.IntersectionObject.Material, point, light, eye, normal);
                canvas.WritePixelColor(color, x, y);

                //if (hit != null) {
                //}
            }
        }
        canvas.SavePPMToFile(canvas.ConvertToPPM(), @"C:\Users\Patrick Quitzau Jens\Documents\CastRayTest1.ppm");
    }

    private static void CastRayTest()
    {
        Point ray_origin = new Point(0, 0, -5);
        double wall_z = 10d;
        double wallSize = 7d;
        int canvasPixels = 400;
        double pixel_size = wallSize / canvasPixels;
        double half = wallSize / 2;
        Canvas canvas = new Canvas(canvasPixels, canvasPixels);
        Sphere s = new Sphere();
        s.Material.Color = new Color(1, 0.2, 1);
        Point lightPosition = new Point(-10, 10, -10);
        Color lightColor = new Color(1, 1, 1);
        PointLight light = new PointLight(lightPosition, lightColor);

        for (int y = 0; y < canvasPixels-1; y++) {
            double world_y = half - pixel_size * y;
            for (int x = 0; x < canvasPixels-1; x++) {
                double world_x = -half + pixel_size * x;
                Point position = new Point(world_x, world_y, wall_z);
                Ray r = new Ray(ray_origin, position.Subtract(ray_origin).Normalize());
                Intersections intersecs = r.Intersections(s);
                Intersection hit = intersecs.FindHit();
                if (hit == null)
                {
                    continue;
                }
                Point point = r.Position(hit.T);
                Vector normal = hit.IntersectionObject.Normal(point);
                Vector eye = r.Direction.Negate();
                               
                Color color = MathOperations.Lighting(hit.IntersectionObject.Material, point, light, eye, normal);
                Console.WriteLine($"Color: [{color.Red}, {color.Blue}, {color.Green}]");
                canvas.WritePixelColor(color, x, y);

                //if (hit != null) {
                //}
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
}



// See https://aka.ms/new-console-template for more information

