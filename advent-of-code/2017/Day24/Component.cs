namespace advent_of_code._2017.Day24;

internal readonly record struct Component(int A, int B)
{
    public int Other(int x) => A == x ? B : A;
    public bool Matches(int x) => A == x || B == x;
    public int Strength => A + B;
}
