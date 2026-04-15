using advent_of_code.Helpers;

namespace advent_of_code._2017.Day20;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var particles = SplitOn.NewLines(input).Select(Particle.Parse).ToArray();

        // Since we are talking about the long term, the acceleration is the most important parameter.

        var bestIndex = 0;

        for (int i = 1; i < particles.Length; i++)
            if (IsBetter(particles[i], particles[bestIndex]))
                bestIndex = i;

        return bestIndex;
    }
    private static bool IsBetter(Particle a, Particle b)
    {
        var aA = a.A.Magnitude();
        var bA = b.A.Magnitude();

        if (aA != bA)
            return aA < bA;

        var aV = a.V.Magnitude();
        var bV = b.V.Magnitude();

        if (aV != bV)
            return aV < bV;

        var aP = a.P.Magnitude();
        var bP = b.P.Magnitude();

        return aP < bP;
    }

    public static int Part2(string input)
    {
        var particles = SplitOn.NewLines(input).Select(Particle.Parse).ToList();
        var ticksSinceLastCollision = 0;

        while (ticksSinceLastCollision < 100)
        {
            // 1. Update all particles
            for (int i = 0; i < particles.Count; i++)
            {
                var p = particles[i];

                // Update Velocity & Position
                p.V = new XYZ(p.V.X + p.A.X, p.V.Y + p.A.Y, p.V.Z + p.A.Z);
                p.P = new XYZ(p.P.X + p.V.X, p.P.Y + p.V.Y, p.P.Z + p.V.Z);

                // Store the particle again (struct type)
                particles[i] = p;
            }

            // 2. Detect collisions
            var groups = particles
                .GroupBy(p => p.P)
                .Where(g => g.Count() > 1)
                .ToList();

            if (groups.Count > 0)
            {
                // Remove all collided particles
                var collided = groups.SelectMany(g => g).ToHashSet();
                particles.RemoveAll(collided.Contains);
                ticksSinceLastCollision = 0;
            }
            else
            {
                ticksSinceLastCollision++;
            }
        }

        return particles.Count;
    }
}
