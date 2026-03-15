using advent_of_code.Helpers;

namespace advent_of_code._Templates.Day21;

internal record Shop(ShopItem[] Weapons, ShopItem[] Armor, ShopItem[] Rings)
{
    public static Shop Parse(string input)
    {
        var parts = SplitOn.EmptyLines(input);

        return new Shop(
            ParseShopItems(parts[0]),
            ParseShopItems(parts[1]),
            ParseShopItems(parts[2])
            );
    }

    public static ShopItem[] ParseShopItems(string input)
        => SplitOn.NewLines(input)
            .Skip(1)    // Skip column header row
            .Select(ShopItem.Parse)
            .ToArray();

    public IEnumerable<ICollection<ShopItem>> AllGearCombinations()
    {
        foreach (var w in Choose(Weapons, 1, 1))
            foreach (var a in Choose(Armor, 0, 1))
                foreach (var r in Choose(Rings, 0, 2))
                    yield return w.Concat(a).Concat(r).ToList();
    }

    public static IEnumerable<List<T>> Choose<T>(IReadOnlyList<T> items, int kMin, int kMax)
    {
        int n = items.Count;

        IEnumerable<List<T>> Recurse(int start, int k)
        {
            if (k == 0)
            {
                yield return new List<T>();
                yield break;
            }

            for (int i = start; i <= n - k; i++)
                foreach (var tail in Recurse(i + 1, k - 1))
                {
                    var list = new List<T>(tail);
                    list.Insert(0, items[i]);
                    yield return list;
                }
        }

        for (int k = kMin; k <= kMax; k++)
            foreach (var subset in Recurse(0, k))
                yield return subset;
    }
}
