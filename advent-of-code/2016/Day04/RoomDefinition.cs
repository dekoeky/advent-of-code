using System.Text.RegularExpressions;

namespace advent_of_code._2016.Day04;

internal partial class RoomDefinition
{
    public string Raw { get; private set; }
    public int SectorId { get; private set; }
    public string EncryptedName { get; private set; }
    public string UnEncryptedName { get; private set; }
    public string CheckSum { get; private set; }

    [GeneratedRegex("^([a-z-]+)-(\\d+)\\[([a-z]{5})\\]$")]
    private static partial Regex GetRegex();
    private static readonly Regex Regex = GetRegex();

    public string DecryptRoomName()
    {
        var letters = EncryptedName.ToArray();

        for (int i = 0; i < letters.Length; i++)
            letters[i] = letters[i] == '-'
                ? ' '
                : RotateRight(letters[i], SectorId);

        var result = new string(letters);

        //Debug.WriteLine(result);

        return result;
    }

    private static char RotateRight(char c, int n)
    {
        // modulo alfabet size
        n %= 26;

        // offset/shift
        var c2 = c + n;

        // if we passed letter z, fold once more
        if (c2 > 'z') c2 -= 26;

        return (char)c2;
    }

    public bool IsReal() => CheckSum == CalculateActualCheckSum();

    public string CalculateActualCheckSum()
    {
        var counts = new Dictionary<char, int>();

        foreach (var letter in UnEncryptedName)
            if (counts.TryGetValue(letter, out int value))
                counts[letter] = ++value;
            else
                counts.Add(letter, 1);

        var mostOccurringCharacters = counts.OrderByDescending(kv => kv.Value)
            .ThenBy(kv => kv.Key)
            .Take(5)
            .Select(kv => kv.Key)
            .ToArray();

        return new string(mostOccurringCharacters);
    }

    public static RoomDefinition Parse(string input)
    {
        var match = Regex.Match(input);

        if (!match.Success) throw new InvalidOperationException();

        var encryptedName = match.Groups[1].Value;

        return new RoomDefinition
        {
            Raw = input,
            EncryptedName = encryptedName,
            UnEncryptedName = encryptedName.Replace("-", null),
            SectorId = int.Parse(match.Groups[2].Value),
            CheckSum = match.Groups[3].Value,
        };
    }
}
