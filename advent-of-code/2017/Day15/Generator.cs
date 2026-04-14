using System.Collections;

namespace advent_of_code._2017.Day15;

internal class Generator : IEnumerator<int>
{
    private const long Div = 2147483647; // 0b1111111111111111111111111111111
    private readonly int _start;
    private readonly long _factor;
    private readonly int? _multipleOf;

    public Generator(int start, int factor, int? multipleOf = null)
    {
        _start = start;
        _factor = factor;
        _multipleOf = multipleOf;
        Current = start;
    }

    public int Current { get; private set; }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        do
            Current = (int)(Current * _factor % Div);
        while (_multipleOf is not null && Current % _multipleOf != 0);

        return true;
    }

    public void Reset()
    {
        Current = _start;
    }

    public void Dispose()
    {
        // Nothing to dispose
    }
}