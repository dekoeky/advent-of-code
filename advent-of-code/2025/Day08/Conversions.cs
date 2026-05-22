namespace advent_of_code._2025.Day08;

public static class Conversions
{
    public static JunctionBox[] ToJunctionBoxes(this JunctionBoxPosition[] positions)
    {
        return positions.Select(p =>
        {
            var c = new Circuit();
            var jb = new JunctionBox
            {
                Position = p,
                Circuit = c,
            };

            c.JunctionBoxes.Add(jb);

            return jb;
        }).ToArray();
    }
}