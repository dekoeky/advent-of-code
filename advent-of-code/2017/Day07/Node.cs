namespace AdventOfCode._2017.Day07;

internal sealed class Node
{
    public string Name { get; }
    public int Weight { get; }
    public List<string> ChildNames { get; } = new();
    public List<Node> Children { get; } = new();

    public Node(string name, int weight)
    {
        Name = name;
        Weight = weight;
    }
}
