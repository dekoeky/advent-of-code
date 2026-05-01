namespace AdventOfCode._2017.Day09;

internal static class Calculations
{
    public static int Solve(ReadOnlySpan<char> input, out int garbageCount)
    {
        int score = 0;
        int depth = 0;
        garbageCount = 0;

        bool garbage = false;
        bool cancel = false;

        foreach (char c in input)
        {
            if (cancel)
            {
                cancel = false;
                continue;
            }

            if (c == '!')
            {
                cancel = true;
                continue;
            }

            if (garbage)
            {
                if (c == '>')
                    garbage = false;
                else
                    garbageCount++;

                continue;
            }

            // Not in garbage
            switch (c)
            {
                case '<':
                    garbage = true;
                    break;

                case '{':
                    depth++;
                    break;

                case '}':
                    score += depth;
                    depth--;
                    break;

                default:
                    break;
            }
        }

        return score;
    }
}