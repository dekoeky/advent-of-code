using advent_of_code.Helpers;

namespace advent_of_code._2017.Day21;

internal record EnhancementRule(string Key, char[,] Pattern, char[,] ReplacePattern, int Size)
{
    public char[][,] AllVariants { get; } = Variants(Pattern, true);
    public char[][,] OtherVariants { get; } = Variants(Pattern, false);

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

    private static char[][,] Variants(char[,] original, bool includeOriginal)
    {
        var variants = new char[includeOriginal ? 8 : 7][,];
        var i = 0;

        // Original
        // A B C
        // D E F
        // G H I
        if (includeOriginal)
            variants[i++] = original;

        // Rotated  90° Right
        // G D A
        // H E B
        // I F C
        var r90 = original.Rotated90();
        variants[i++] = r90;

        // Rotated 180° Right
        // I H G
        // F E D
        // C B A
        var r180 = r90.Rotated90();
        variants[i++] = r180;

        // Rotated 270° Right (Or 90° Left)
        // C F I
        // B E H
        // A D G
        var r270 = r180.Rotated90();
        variants[i++] = r270;

        // Flipped Horizontally
        // C B A
        // F E D
        // I H G
        var f = original.FlippedHorizontal();
        variants[i++] = f;

        // Flipped Horizontally + Rotated 90° Right
        // I F C
        // H E B
        // G D A
        var f90 = f.Rotated90();
        variants[i++] = f90;

        // Flipped Horizontally + Rotated 180° Right (Or Original Flipped Vertically)
        // G H I
        // D E F
        // A B C
        var f180 = f90.Rotated90();
        variants[i++] = f180;

        // Flipped Horizontally + Rotated 270° Right
        // A D G
        // B E H
        // C F I
        var f270 = f180.Rotated90();
        variants[i++] = f270;

        return variants;
    }
}