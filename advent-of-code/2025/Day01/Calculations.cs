using System.Diagnostics;

namespace advent_of_code._2025.Day01;

public static class Calculations
{
    private const int Start = 50;
    private static readonly string[] NewLineStrings = ["\r\n", "\r", "\n"];

    public static IEnumerable<Rotation> GetRotations(string input)
    {
        var lines = input.Split(NewLineStrings, StringSplitOptions.None);

        foreach (var line in lines)
            yield return Rotation.Parse(line);

    }
    public static int CountZeroes(string rotations) => CountZeroes(GetRotations(rotations));

    public static int CountZeroes(IEnumerable<Rotation> rotations)
    {
        var zeroes = 0;

        Debug.WriteLine($"The dial starts by pointing at {Start}.");
        var dial = Start;

        foreach (var rotation in rotations)
        {
            dial += rotation;
            if (dial == 0) zeroes++;
            Debug.WriteLine($"The dial is rotated {rotation} to point at {dial}.");
        }

        return zeroes;
    }


    public static int CountZeroesV2(string rotations) => CountZeroesV2(GetRotations(rotations));

    public static int CountZeroesV2(IEnumerable<Rotation> rotations)
    {
        var zeroes = 0;

        Debug.WriteLine($"The dial starts by pointing at {Start}.");
        var dial = Start;

        foreach (var rotation in rotations)
        {
            foreach (var click in rotation.GetClicks())
            {
                dial += click;

                if (dial == 0)
                {
                    zeroes++;
                    Debug.WriteLine($"The dial points to '0' during rotation {rotation}");
                }
            }

            Debug.WriteLine($"The dial is rotated {rotation} to point at {dial}.");
        }

        return zeroes;
    }
}
