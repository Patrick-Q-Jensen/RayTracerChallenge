namespace RayTracerChallengeTestSuite;

public class PatternTests
{
    [Fact]
    public void StripePatternConstructor()
    {
        Pattern p = new Striped(new Color(1, 1, 1), new Color(0, 0, 0));
        p.A.Equals(new Color(1, 1, 1)).Should().BeTrue();
        p.B.Equals(new Color(0, 0, 0)).Should().BeTrue();
    }

    [Fact]
    public void StripePatternIsConstantInY()
    {
        Color white = new Color(1, 1, 1);
        Color black = new Color(0, 0, 0);
        Pattern p = new Striped(white, black);
        p.ColorAt(new Point(0, 0, 0)).Equals(white).Should().BeTrue();
        p.ColorAt(new Point(0, 1, 0)).Equals(white).Should().BeTrue();
        p.ColorAt(new Point(0, 2, 0)).Equals(white).Should().BeTrue();
    }

    [Fact]
    public void StripePatternIsConstantInZ()
    {
        Color white = new Color(1, 1, 1);
        Color black = new Color(0, 0, 0);
        Pattern p = new Striped(white, black);
        p.ColorAt(new Point(0, 0, 0)).Equals(white).Should().BeTrue();
        p.ColorAt(new Point(0, 0, 1)).Equals(white).Should().BeTrue();
        p.ColorAt(new Point(0, 0, 2)).Equals(white).Should().BeTrue();
    }

    [Fact]
    public void StripePatternAlternatesInX()
    {
        Color white = new Color(1, 1, 1);
        Color black = new Color(0, 0, 0);
        Pattern p = new Striped(white, black);
        p.ColorAt(new Point(0, 0, 0)).Equals(white).Should().BeTrue();
        p.ColorAt(new Point(0.9, 0, 0)).Equals(white).Should().BeTrue();
        p.ColorAt(new Point(1, 0, 0)).Equals(black).Should().BeTrue();
        p.ColorAt(new Point(-0.1, 0, 0)).Equals(black).Should().BeTrue();
        p.ColorAt(new Point(-1, 0, 0)).Equals(black).Should().BeTrue();
        p.ColorAt(new Point(-1.1, 0, 0)).Equals(white).Should().BeTrue();
    }

    [Fact]
    public void LightingWithAPatternApplied()
    {
        Sphere s = new Sphere();
        s.Material = new(1, 0, 0);
        //Material m = new(1,0,0);
        Color white = new(1, 1, 1);
        Color black = new(0, 0, 0);
        s.Material.Pattern = new Striped(white, black);
        Vector eyev = new(0,0,-1);
        Vector normalV = new(0,0,-1);
        PointLight light = new(new Point(0, 0, -10), new Color(1,1,1));
        Color c1 = MathOperations.Lighting(s, new Point(0.9,0,0), light, eyev, normalV, false);
        Color c2 = MathOperations.Lighting(s, new Point(1.1,0,0), light, eyev, normalV, false);
        c1.Equals(white).Should().BeTrue();
        c2.Equals(black).Should().BeTrue();
    }

    [Fact]
    public void StripedWithObjectTransformation()
    {
        Color white = new(1, 1, 1);
        Color black = new(0, 0, 0);
        Sphere s = new Sphere();
        s.SetTransformation(MathOperations.Scaling(2, 2, 2));
        Pattern p = new Striped(white, black);
        s.Material.Pattern = p;
        Color c = s.ColorAt(new Point(1.5, 0, 0));
        c.Equals(white).Should().BeTrue();
    }

    [Fact]
    public void StripedWithPatternTransformation()
    {
        Color white = new(1, 1, 1);
        Color black = new(0, 0, 0);
        Sphere s = new Sphere();
        //s.SetTransformation(MathOperations.Scaling(2, 2, 2));
        Pattern p = new Striped(white, black, MathOperations.Scaling(2, 2, 2));
        s.Material.Pattern = p;
        Color c = s.ColorAt(new Point(1.5, 0, 0));
        c.Equals(white).Should().BeTrue();
    }

    [Fact]
    public void StripedWithPatternAndObjectTransformation()
    {
        Color white = new(1, 1, 1);
        Color black = new(0, 0, 0);
        Sphere s = new Sphere();
        s.SetTransformation(MathOperations.Scaling(2, 2, 2));
        Pattern p = new Striped(white, black, MathOperations.Translation(0.5, 0, 0));
        s.Material.Pattern = p;
        Color c = s.ColorAt(new Point(2.5, 0, 0));
        c.Equals(white).Should().BeTrue();
    }

    [Fact]
    public void AGradientLinearlyInterpolatesBetweenColors()
    {
        Color white = new(1, 1, 1);
        Color black = new(0, 0, 0);
        Pattern grad = new Gradiant(white, black);
        grad.ColorAt(new Point(0,0,0)).Equals(white).Should().BeTrue();
        grad.ColorAt(new Point(0.25,0,0)).Equals(new Color(0.75, 0.75, 0.75)).Should().BeTrue();
        grad.ColorAt(new Point(0.5,0,0)).Equals(new Color(0.5, 0.5, 0.5)).Should().BeTrue();
        grad.ColorAt(new Point(0.75,0,0)).Equals(new Color(0.25, 0.25, 0.25)).Should().BeTrue();
    }

    [Fact]
    public void ARingShouldExtendInBothXandZ()
    {
        Color white = new(1, 1, 1);
        Color black = new(0, 0, 0);
        Pattern ringed = new Ringed(white, black);
        ringed.ColorAt(new Point(0, 0, 0)).Equals(white).Should().BeTrue();
        ringed.ColorAt(new Point(1, 0, 0)).Equals(black).Should().BeTrue();
        ringed.ColorAt(new Point(0, 0, 1)).Equals(black).Should().BeTrue();
        ringed.ColorAt(new Point(0.708, 0, 0.708)).Equals(black).Should().BeTrue();

    }
}
