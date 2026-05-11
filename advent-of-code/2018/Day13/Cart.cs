namespace advent_of_code._2018.Day13;

internal class Cart
{
    public Point Position { get; set; }
    public char Direction { get; set; } = '-';

    public int CrossRoadCounter { get; set; } = 0;
}
