namespace advent_of_code._2017.Day21;

internal record EnhancementRule(string Key, char[,] Pattern, char[,] ReplacePattern, int Size)
{
    public char[][,] AllVariants { get; } = Pattern.Variants(true);
    public char[][,] OtherVariants { get; } = Pattern.Variants(false);

    public static EnhancementRule Parse(string input)
    {
        var parts = input.Split(" => ");
        var key = parts[0];

        parts = [.. parts.Select(s => s.Replace("/", Environment.NewLine))];

        var pattern = parts[0].To2DArray();
        var replacePattern = parts[1].To2DArray();
        var size = pattern.GetLength(0);
        if (size != pattern.GetLength(1)) throw new InvalidOperationException("not square");

        return new EnhancementRule(key, pattern, replacePattern, size);
    }
}