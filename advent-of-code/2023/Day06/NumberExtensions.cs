using System.Numerics;

namespace AdventOfCode._2023.Day06;

public static class NumberExtensions
{
    public static T CalculateProduct<T>(this IEnumerable<T> numbers) where T : INumber<T> => numbers.Aggregate(T.One, (current, number) => current * number);
}