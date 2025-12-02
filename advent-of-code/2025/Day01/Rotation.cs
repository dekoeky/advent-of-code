namespace advent_of_code._2025.Day01;

public readonly struct Rotation(int delta)
{
    public int Delta { get; } = delta;

    public static int operator +(int a, Rotation b) => Normalize(a + b.Delta);

    private static int Normalize(int i) => (i % 100 + 100) % 100;

    public override string ToString() => Delta >= 0
        ? $"R{+Delta}"
        : $"L{-Delta}";

    public static Rotation Parse(string s)
    {
        var number = int.Parse(s.AsSpan(1));

        return s[0] switch
        {
            'R' => new Rotation(+number),
            'L' => new Rotation(-number),
            _ => throw new InvalidOperationException()
        };
    }

    private static readonly Rotation ClickRight = new(+1);
    private static readonly Rotation ClickLeft = new(-1);

    public IEnumerable<Rotation> GetClicks()
    {
        if (Delta >= 0)
        {
            for (var i = 0; i < Delta; i++)
                yield return ClickRight;
        }
        else
        {
            for (var i = 0; i > Delta; i--)
                yield return ClickLeft;
        }
    }
}