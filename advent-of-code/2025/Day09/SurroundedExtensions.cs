namespace advent_of_code._2025.Day09;

internal static class SurroundedExtensions
{
    extension(RowCol[] tiles)
    {
        public bool Surrounded(RowCol rc)
        {
            return tiles.Any(t => t.Row == rc.Row && t.Col < rc.Col)
                && tiles.Any(t => t.Row == rc.Row && t.Col > rc.Col)
                && tiles.Any(t => t.Col == rc.Col && t.Row < rc.Row)
                && tiles.Any(t => t.Col == rc.Col && t.Row > rc.Row)
                ;
        }
    }
}