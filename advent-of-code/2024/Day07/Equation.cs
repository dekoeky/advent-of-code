namespace advent_of_code._2024.Day07;

public class Equation
{
    public required long TestValue { get; set; }
    public required long[] Values { get; set; }

    public static Equation Parse(string input)
    {
        var parts = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 2) throw new InvalidOperationException();

        var result = long.Parse(parts[0]);

        parts = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var values = parts.Select(long.Parse).ToArray();

        return new Equation()
        {
            TestValue = result,
            Values = values,
        };
    }
}