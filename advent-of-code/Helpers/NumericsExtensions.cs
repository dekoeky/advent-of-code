using System.Numerics;

namespace advent_of_code.Helpers;

internal static class NumericsExtensions
{
    extension<TIn>(IEnumerable<TIn> elements)
            where TIn : struct, INumberBase<TIn>
    {
        public TOut Product<TOut>()
            where TOut : struct, INumberBase<TOut>
        {
            var product = TOut.One;

            foreach (var element in elements)
                product *= TOut.CreateChecked(element);

            return product;
        }

        public TIn Product() => elements.Product<TIn, TIn>();
    }
}