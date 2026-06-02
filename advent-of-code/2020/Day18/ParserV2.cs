namespace advent_of_code._2020.Day18;

internal ref struct ParserV2
{
    private readonly ReadOnlySpan<char> _s;
    private int _i;

    public ParserV2(ReadOnlySpan<char> s)
    {
        _s = s;
        _i = 0;
    }

    // Expression := Sum ( '*' Sum )*
    public long ParseExpression()
    {
        long value = ParseSum();

        while (TryPeek(out char c) && c == '*')
        {
            _i++; // consume '*'
            long rhs = ParseSum();
            value *= rhs;
        }

        return value;
    }

    // Sum := Term ( '+' Term )*
    private long ParseSum()
    {
        long value = ParseTerm();

        while (TryPeek(out char c) && c == '+')
        {
            _i++; // consume '+'
            long rhs = ParseTerm();
            value += rhs;
        }

        return value;
    }

    private long ParseTerm()
    {
        SkipSpaces();

        if (_s[_i] == '(')
        {
            _i++; // consume '('
            long v = ParseExpression();
            _i++; // consume ')'
            return v;
        }

        return ParseNumber();
    }

    private long ParseNumber()
    {
        long n = 0;
        while (_i < _s.Length && char.IsDigit(_s[_i]))
        {
            n = n * 10 + (_s[_i] - '0');
            _i++;
        }
        return n;
    }

    private void SkipSpaces()
    {
        while (_i < _s.Length && _s[_i] == ' ')
            _i++;
    }

    private bool TryPeek(out char c)
    {
        SkipSpaces();
        if (_i < _s.Length)
        {
            c = _s[_i];
            return true;
        }
        c = default;
        return false;
    }
}
