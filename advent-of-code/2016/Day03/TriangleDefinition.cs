namespace advent_of_code._2016.Day03;

internal record struct TriangleDefinition(int A, int B, int C)
{
    public readonly bool IsValid()
        => (A + B) > C
        && (B + C) > A
        && (A + C) > B;
}
