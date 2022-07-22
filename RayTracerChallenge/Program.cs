namespace RayTracerChallenge;

internal class Program {
    static void Main(string[] args) {
       

    }

    private static void DrawClock()
    {
        Canvas canvas = new Canvas(500, 500);
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

