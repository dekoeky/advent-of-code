namespace AdventOfCode._2025.Day08;

public class JunctionBox
{
    public JunctionBoxPosition Position { get; set; }
    public required Circuit Circuit { get; set; }

    public override string ToString()
    {
        return $"({Circuit.Id}){Position.X},{Position.Y},{Position.Z}";
    }
}
