namespace advent_of_code._2018.Day10;

internal struct PositionVelocity
{
    public PositionVelocity() => throw new InvalidOperationException("Not intended to be used");

    public static int ParseMany(ReadOnlySpan<char> input, out Position[] positions, out Velocity[] velocities)
    {
        int n = input.Count('\n') + 1;
        int i = 0;
        positions = new Position[n];
        velocities = new Velocity[n];

        foreach (ReadOnlySpan<char> line in input.EnumerateLines())
        {
            Parse(line, out var position, out var velocity);

            positions[i] = position;
            velocities[i] = velocity;

            i++;
        }

        return n;
    }

    public static void Parse(ReadOnlySpan<char> input, out Position position, out Velocity velocity)
    {
        var i = input.IndexOf('<') + 1;
        var j = input.IndexOf('>');
        position = Position.Parse(input[i..j]);

        i = input.LastIndexOf('<') + 1;
        j = input.LastIndexOf('>');
        velocity = Velocity.Parse(input[i..j]);
    }
}