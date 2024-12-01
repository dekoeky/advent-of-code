namespace advent_of_code._2024._01.Puzzle1;

public static class InputParsing
{
    static readonly char[] lineChars = ['\r', '\n'];
    public static void ParseInput(string input, out List<int> list1, out List<int> list2)
    {
        var lines = input.Split(lineChars, StringSplitOptions.RemoveEmptyEntries);
        list1 = new List<int>();
        list2 = new List<int>();

        foreach (var line in lines)
        {
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
                throw new InvalidOperationException("Invalid input");

            list1.Add(int.Parse(parts[0]));
            list2.Add(int.Parse(parts[1]));
        }
    }
}
