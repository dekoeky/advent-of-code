namespace advent_of_code._2023._05;

public class Names
{
    public static (string Source, string Destination) Parse(string s)
    {
        //Cut away ' map:'
        s = s[..^" map:".Length];

        var parts = s.Split("-to-");

        return (parts[0], parts[1]);
    }
}