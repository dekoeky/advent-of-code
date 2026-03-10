using System.Text.Json;

namespace advent_of_code._2015.Day12;

internal static class Calculations
{
    public static int JsonSum(string input, bool ignoreRed)
    {
        var jsonDoc = JsonDocument.Parse(input);

        return JsonSum(jsonDoc.RootElement, ignoreRed);
    }

    private static int JsonSum(JsonElement element, bool ignoreRed)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Number: return JsonSumNumber(element);
            case JsonValueKind.Object: return JsonSumObject(element, ignoreRed);
            case JsonValueKind.Array: return JsonSumArray(element, ignoreRed);
            default: return 0;
        }
    }

    private static int JsonSumNumber(JsonElement element)
    {
        if (element.ValueKind != JsonValueKind.Number) throw new InvalidDataException("only numbers allowed");
        return element.GetInt32();
    }

    private static int JsonSumObject(JsonElement element, bool ignoreRed)
    {
        if (element.ValueKind != JsonValueKind.Object) throw new InvalidOperationException("only objects allowed");

        var sum = 0;

        foreach (var child in element.EnumerateObject())
            if (ignoreRed && child.Value.ValueKind == JsonValueKind.String && child.Value.GetString() == "red")
                return 0;
            else
                sum += JsonSum(child.Value, ignoreRed);

        return sum;
    }

    private static int JsonSumArray(JsonElement element, bool ignoreRed)
    {
        if (element.ValueKind != JsonValueKind.Array) throw new InvalidOperationException("only arrays allowed");

        var sum = 0;

        foreach (var child in element.EnumerateArray())
            sum += JsonSum(child, ignoreRed);

        return sum;
    }
}