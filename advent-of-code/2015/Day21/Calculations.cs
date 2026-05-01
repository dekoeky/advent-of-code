namespace AdventOfCode._2015.Day21;

internal static class Calculations
{
    public static int CheapestWin(Character player, Character boss, Shop shop)
    {
        foreach (var setOfItems in shop.AllGearCombinations().OrderBy(gear => gear.Sum(g => g.Cost)))
        {
            player.SetGear(setOfItems);

            if (Battle(player, boss))
                return player.Gear.Sum(g => g.Cost);
        }

        throw new InvalidOperationException("No solution found");
    }


    public static int MostExpensiveLoss(Character player, Character boss, Shop shop)
    {
        foreach (var setOfItems in shop.AllGearCombinations().OrderByDescending(gear => gear.Sum(g => g.Cost)))
        {
            player.SetGear(setOfItems);

            if (!Battle(player, boss))
                return player.Gear.Sum(g => g.Cost);
        }

        throw new InvalidOperationException("No solution found");
    }

    static bool Battle(Character player, Character boss)
    {
        player.RestoreHealth();
        boss.RestoreHealth();

        // Anounce battle
        Debug.WriteLine("=========================================");
        Debug.WriteLine($"Battle starting");
        Debug.WriteLine($"  Player: {player.Name,6}, Health: {player.Health,3}, Armor: {player.TotalArmor,3}, Damage: {player.TotalDamage,3}");
        Debug.WriteLine($"  Boss:   {boss.Name,6}, Health: {boss.Health,3}, Armor: {boss.TotalArmor,3}, Damage: {boss.TotalDamage,3}");
        Debug.WriteLine();

        // Print gear
        Debug.WriteLine("Player Gear:");
        Debug.WriteLine($"  {string.Join(Environment.NewLine + "  ", player.Gear)}");
        Debug.WriteLine();

        while (true)
        {
            // Player Strikes First
            if (Attack(player, boss)) return true;
            if (Attack(boss, player)) return false;

            Debug.WriteLine();
        }

        static bool Attack(Character attacker, Character target)
        {
            // Damage dealt by an attacker each turn is equal to the attacker's damage score minus the defender's armor score.
            // An attacker always does at least 1 damage.
            // So, if the attacker has a damage score of 8, and the defender has an armor score of 3, the defender loses 5 hit points.
            // If the defender had an armor score of 300, the defender would still lose 1 hit point.

            // Calculate the damage
            //var damage = Math.Max(1, attacker.TotalDamage - target.TotalArmor);
            var damage = Math.Max(1, attacker.TotalDamage - target.TotalArmor);

            // Apply the damage
            target.Health -= damage;

            Debug.WriteLine($"{attacker.Name,10} dealt {attacker.TotalDamage,3} - {target.TotalArmor,3} = {damage} damage. " +
                $"{target.Name,10} health now {target.Health}");

            // Check if killed
            return target.Health <= 0;
        }
    }
}
