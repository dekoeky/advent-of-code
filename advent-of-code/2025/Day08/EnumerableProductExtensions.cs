using System.Numerics;

namespace advent_of_code._2025.Day08;

public static class EnumerableProductExtensions
{
    public static TOut Product<TIn, TOut>(this IEnumerable<TIn> values, Func<TIn, TOut> selector)
        where TOut : INumber<TOut>
    {
        var product = TOut.CreateChecked(1);

        foreach (var value in values)
            product *= selector(value);

        return product;
    }
}