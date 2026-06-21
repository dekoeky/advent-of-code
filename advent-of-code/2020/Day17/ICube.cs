namespace advent_of_code._2020.Day17;

public interface ICube<TSelf>
{
    IEnumerable<TSelf> EnumerateNeighbors();
    static abstract TSelf From2D(int x, int y);
}
