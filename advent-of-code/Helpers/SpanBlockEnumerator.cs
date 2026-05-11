namespace advent_of_code.Helpers;

public ref struct SpanBlockEnumerator
{
    private ReadOnlySpan<char> _remaining;

    public SpanBlockEnumerator(ReadOnlySpan<char> span)
    {
        _remaining = span;
        Current = default;
    }

    public ReadOnlySpan<char> Current { get; private set; }

    public SpanBlockEnumerator GetEnumerator() => this;

    public bool MoveNext()
    {
        var span = _remaining;

        // Skip empty lines
        while (true)
        {
            if (span.IsEmpty)
                return false;


            int lineLength = GetLineLength(span, out int totalLength);

            if (lineLength != 0)
                break;

            span = span[totalLength..];
        }

        var blockStart = _remaining.Length - span.Length;

        // Consume non-empty lines
        while (!span.IsEmpty)
        {
            var lineLength = GetLineLength(span, out int totalLength);

            if (lineLength == 0)
                break;

            span = span[totalLength..];
        }

        var blockEnd = _remaining.Length - span.Length;

        // Trim trailing CR/LF
        while (blockEnd > blockStart)
        {
            char c = _remaining[blockEnd - 1];

            if (c == '\r' || c == '\n')
                blockEnd--;
            else
                break;
        }

        Current = _remaining[blockStart..blockEnd];
        _remaining = span;

        return true;
    }

    private static int GetLineLength(
        ReadOnlySpan<char> span,
        out int totalLength)
    {
        int index = span.IndexOfAny('\r', '\n');

        if (index < 0)
        {
            totalLength = span.Length;
            return span.Length;
        }

        var newlineLength = 1;

        if (span[index] == '\r'
            && index + 1 < span.Length
            && span[index + 1] == '\n')
        {
            newlineLength = 2;
        }

        totalLength = index + newlineLength;

        return index;
    }
}