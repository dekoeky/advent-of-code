namespace advent_of_code._2024.Day07;

public class PuzzleInput
{
    public List<Equation> Equations { get; set; }

    public static PuzzleInput Parse(string input)
    {
        var lines = input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var equations = lines.Select(Equation.Parse);

        return new PuzzleInput
        {
            Equations = equations.ToList()
        };
    }
}