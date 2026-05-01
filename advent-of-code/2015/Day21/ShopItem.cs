namespace AdventOfCode._2015.Day21;

internal record ShopItem(string Name, int Cost, int Damage, int Armor)
{
    public static ShopItem Parse(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var cost = int.Parse(parts[^3]);
        var damage = int.Parse(parts[^2]);
        var armor = int.Parse(parts[^1]);

        // Workaround for the fact that the name can be "damage +1"
        var name = string.Join(' ', parts[..^3]);

        return new ShopItem(name, cost, damage, armor);
    }
}
