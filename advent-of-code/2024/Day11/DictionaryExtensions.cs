using System.Numerics;

namespace advent_of_code._2024.Day11;

internal static class DictionaryExtensions
{
    extension<T>(Dictionary<T, T> dict) where T : INumber<T>
    {
        public void IncreaseValue(T key, T add)
            => dict[key] = dict.TryGetValue(key, out var existing)
            ? existing + add
            : add;
    }
}