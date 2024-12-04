namespace advent_of_code._2024.Day02;

internal class UnusualData
{
    static readonly char[] lineChars = ['\r', '\n'];
    public static UnusualData Parse(string input)
    {
        var lines = input.Split(lineChars, StringSplitOptions.RemoveEmptyEntries);

        return new UnusualData
        {
            Reports = lines.Select(Report.Parse).ToArray()
        };
    }

    public required Report[] Reports { get; set; }
}
