namespace RayTracerChallenge;

internal class Environment
{
    public Vector Gravity;
    public Vector Wind;

    public Environment(Vector gravity, Vector wind)
    {
        Gravity = gravity;
        Wind = wind;
    }
}

