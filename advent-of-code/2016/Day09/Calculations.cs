using System.Text;

namespace AdventOfCode._2016.Day09;

internal static class Calculations
{
    public static string DecompressV1(ReadOnlySpan<char> input)
    {
        var sb = new StringBuilder();
        int i;
        for (i = 0; i < input.Length; i++)
        {
            var c = input[i];

            if (c == '(')
            {
                var (count, repeat) = ReadMarker(input);

                var rest = input[(i + 1)..];

                // Cant process pattern if end of input string
                if (rest.Length < 1) break;

                //// Should not repeat pattern if pattern starts with '('
                //if (rest[0] == '(')
                //{
                //    var l = rest.IndexOf(')') + 1;
                //    sb.Append(rest[..l]);
                //    i += l;
                //    continue;
                //}

                for (var r = 0; r < repeat; r++)
                    sb.Append(rest[..count]);

                // Skip the repeated pattern
                i += count;
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();

        (int count, int repeat) ReadMarker(ReadOnlySpan<char> input)
        {
            // Ignore '('
            i++;

            var index = input.Slice(i).IndexOf('x');
            var count = int.Parse(input.Slice(i, index));

            // Ignore 'x'
            i += index + 1;
            index = input.Slice(i).IndexOf(')');
            var repeat = int.Parse(input.Slice(i, index));

            // Set index to ')'
            i += index;

            return (count, repeat);
        }
    }

    public static long DecompressV2(ReadOnlySpan<char> input)
    {
        long total = 0;

        for (int i = 0; i < input.Length; i++)
            if (input[i] == '(')
            {
                var (count, repeat, newIndex) = ReadMarker(input, i);
                i = newIndex;

                var segment = input.Slice(i + 1, count);
                long innerLength = DecompressV2(segment);

                total += innerLength * repeat;

                i += count;
            }
            else
            {
                total++;
            }

        return total;
    }

    private static (int count, int repeat, int endIndex) ReadMarker(ReadOnlySpan<char> input, int i)
    {
        i++; // skip '('
        var x = input[i..].IndexOf('x');
        var count = int.Parse(input.Slice(i, x));

        i += x + 1;
        var end = input[i..].IndexOf(')');
        var repeat = int.Parse(input.Slice(i, end));

        var endIndex = i + end; // index of ')'

        return (count, repeat, endIndex);
    }
}