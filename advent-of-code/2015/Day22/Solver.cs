namespace advent_of_code._2015.Day22;

public static class Solver
{
    public static int FindLeastManaToWin(int bossHp, int bossDamage, bool hardMode)
    {
        int best = int.MaxValue;

        void Search(GameState state)
        {
            if (state.ManaSpent >= best)
                return;

            // Hard mode penalty
            if (hardMode)
            {
                state = state with { PlayerHp = state.PlayerHp - 1 };
                if (state.PlayerDead)
                    return;
            }

            // Start of player turn
            state = ApplyEffects(state);
            if (state.BossDead)
            {
                best = Math.Min(best, state.ManaSpent);
                return;
            }

            // Try all spells
            foreach (var spell in Spell.All)
            {
                var afterCast = CastSpell(state, spell);
                if (afterCast.PlayerDead)
                    continue;

                if (afterCast.BossDead)
                {
                    best = Math.Min(best, afterCast.ManaSpent);
                    continue;
                }

                // Boss turn: apply effects
                var bossTurn = ApplyEffects(afterCast);
                if (bossTurn.BossDead)
                {
                    best = Math.Min(best, bossTurn.ManaSpent);
                    continue;
                }

                // Boss attacks
                int dmg = Math.Max(1, bossDamage - bossTurn.PlayerArmor);
                bossTurn = bossTurn with { PlayerHp = bossTurn.PlayerHp - dmg };

                if (!bossTurn.PlayerDead)
                    Search(bossTurn);
            }
        }

        var start = new GameState(
            PlayerHp: 50,
            PlayerMana: 500,
            BossHp: bossHp,
            BossDamage: bossDamage,
            ManaSpent: 0,
            ActiveEffects: Array.Empty<Effect>()
        );

        Search(start);
        return best;
    }

    public static GameState CastSpell(GameState s, Spell spell)
    {
        // Cannot afford
        if (s.PlayerMana < spell.Cost)
            return s with { PlayerHp = -999 };

        // Cannot cast an already-active effect
        if (spell.Effect is not null &&
            s.ActiveEffects.Any(e => e.Name == spell.Effect.Name))
            return s with { PlayerHp = -999 };

        int hp = s.PlayerHp + spell.InstantHeal;
        int mana = s.PlayerMana - spell.Cost;
        int boss = s.BossHp - spell.InstantDamage;

        var effects = s.ActiveEffects.ToList();
        if (spell.Effect is not null)
            effects.Add(spell.Effect);

        return s with
        {
            PlayerHp = hp,
            PlayerMana = mana,
            BossHp = boss,
            ManaSpent = s.ManaSpent + spell.Cost,
            ActiveEffects = effects
        };
    }

    public static GameState ApplyEffects(GameState s)
    {
        int hp = s.PlayerHp;
        int mana = s.PlayerMana;
        int boss = s.BossHp;

        var remaining = new List<Effect>();

        foreach (var e in s.ActiveEffects)
        {
            if (e.Damage > 0)
                boss -= e.Damage;

            if (e.Mana > 0)
                mana += e.Mana;

            if (e.Timer > 1)
                remaining.Add(e with { Timer = e.Timer - 1 });
        }

        return s with
        {
            PlayerHp = hp,
            PlayerMana = mana,
            BossHp = boss,
            ActiveEffects = remaining
        };
    }
}