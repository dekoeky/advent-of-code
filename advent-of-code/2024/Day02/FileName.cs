namespace advent_of_code._2024.Day02;

internal class Report
{
    public required int[] Levels { get; set; }

    public static Report Parse(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return new Report
        {
            Levels = parts.Select(int.Parse).ToArray(),
        };
    }

    public override string ToString() => string.Join(' ', Levels);
}