using advent_of_code.Helpers;

namespace advent_of_code._2015.Day21;

internal record Character(string Name, int HitPoints, int NativeDamage, int NativeArmor)
{
    public static Character Parse(string input, string? name)
    {
        var properties = SplitOn.NewLines(input)
            .Select(l => l.Split(':', StringSplitOptions.TrimEntries))
            .ToDictionary(p => p[0], p => int.Parse(p[1]));

        return new Character(
            Name: name ?? "???",
            HitPoints: properties["Hit Points"],
            NativeDamage: properties["Damage"],
            NativeArmor: properties["Armor"]
            );
    }

    public int Health { get; set; } = HitPoints;
    public int TotalDamage { get; set; } = NativeDamage;
    public int TotalArmor { get; set; } = NativeArmor;

    public IReadOnlyCollection<ShopItem> Gear { get; private set; } = [];
    public void SetGear(ICollection<ShopItem> gear)
    {
        Gear = [.. gear];
        ReCalculateStats();
    }

    public void RestoreHealth()
    {
        Health = HitPoints;
    }

    private void ReCalculateStats()
    {
        TotalDamage = NativeDamage + Gear.Sum(i => i.Damage);
        TotalArmor = NativeArmor + Gear.Sum(i => i.Armor);
    }
}
