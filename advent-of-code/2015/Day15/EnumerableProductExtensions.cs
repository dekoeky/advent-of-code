using System.Numerics;

namespace AdventOfCode._2015.Day15;

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