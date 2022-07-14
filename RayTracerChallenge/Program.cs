namespace RayTracerChallenge;

internal class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");
        Environment env = new Environment(new Vector(0,-0.1,0), new Vector(-0.001,0,0));
        Projectile proj = new Projectile(new Point(0, 1, 0), MathOperations.NormalizeVector(new Vector(1,2,0)));
        int tickCount = 0;
        while (proj.Position.Y > 0.00f)
        {
            proj = Tick(proj, env);
            tickCount++;
            Console.WriteLine($"Projectile position: X:[{proj.Position.X}] Y:[{proj.Position.Y}] Z:[{proj.Position.Z}]");
        }

        Console.WriteLine($"Tick count: {tickCount}");
    }

    private static Projectile Tick(Projectile proj, Environment env) {

        Point position = MathOperations.AddPointAndVector(proj.Position, proj.Velocity);
        Vector gravityAndWind = (Vector)MathOperations.AddTuples(env.Gravity, env.Wind);
        Vector velocity = (Vector)MathOperations.AddTuples(proj.Velocity, gravityAndWind);        
        return new Projectile(position, velocity);
    }
}



// See https://aka.ms/new-console-template for more information

