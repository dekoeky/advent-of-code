namespace advent_of_code._Templates.Day22;

public record Spell(string Name, int Cost, int InstantDamage, int InstantHeal, Effect? Effect)
{
    public static readonly Spell[] All =
    [
        new("Magic Missile", 53, 4, 0, null),
        new("Drain",         73, 2, 2, null),
        new("Shield",       113, 0, 0, new Effect("Shield", 6, 7, 0,   0)),
        new("Poison",       173, 0, 0, new Effect("Poison", 6, 0, 3,   0)),
        new("Recharge",     229, 0, 0, new Effect("Recharge", 5, 0, 0, 101)),
    ];
}
