namespace advent_of_code._2015.Day22;

public record GameState(
    int PlayerHp,
    int PlayerMana,
    int BossHp,
    int BossDamage,
    int ManaSpent,
    IReadOnlyList<Effect> ActiveEffects
)
{
    public bool PlayerDead => PlayerHp <= 0;
    public bool BossDead => BossHp <= 0;

    public int PlayerArmor =>
        ActiveEffects.Where(e => e.Armor > 0).Sum(e => e.Armor);
}
