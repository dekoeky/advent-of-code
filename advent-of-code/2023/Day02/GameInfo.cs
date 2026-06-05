namespace advent_of_code._2023.Day02;

public record GameInfo(int Id, RedGreenBlue[] Grabs)
{
    public static GameInfo Parse(ReadOnlySpan<char> line)
    {
        var i = line.IndexOf(':');
        var id = int.Parse(line[new Range(5, i)]);

        // Cut away the header
        line = line[++i..];

        var values = RedGreenBlue.ParseMany(line);


        return new GameInfo(id, values);
    }

    public static GameInfo[] ParseMany(ReadOnlySpan<char> input)
    {
        var i = 0;
        var n = input.Count('\n') + 1;
        GameInfo[] infos = new GameInfo[n];

        foreach (var line in input.EnumerateLines())
            infos[i++] = Parse(line);

        return infos;
    }
}