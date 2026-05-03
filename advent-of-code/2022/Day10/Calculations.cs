namespace advent_of_code._2022.Day10;

internal static partial class Calculations
{
    public static long Part1(ReadOnlySpan<char> input)
    {
        var cycle = 0;
        var duration = 0;
        int? v = 0;
        var x = 1;
        Dictionary<int, int> signalStrenghts = [];
        Span<int> effects = stackalloc int[3];

        foreach (var line in input.EnumerateLines())
        {
            // 1. Parse
            if (line.StartsWith("noop"))
            {
                v = null;
                duration = 1;
            }
            else if (line.StartsWith("addx"))
            {
                v = int.Parse(line[5..]);
                duration = 2;
            }

            // Run Cycles
            for (var c = 0; c < duration; c++)
            {
                cycle++;
                SampleSignalStrength();
            }

            // Update value at end of cycle
            if (v is not null)
                x += v.Value;
        }

        return signalStrenghts.Values.Sum();

        void SampleSignalStrength()
        {
            if (cycle != 20 && (cycle - 20) % 40 != 0)
                return;

            var ss = cycle * x;
            Debug.WriteLine($"Cycle: {cycle} -> {ss}");
            signalStrenghts.Add(cycle, ss);
        }
    }

    public static string Part2(ReadOnlySpan<char> input)
    {
        Span<char> crt = stackalloc char[240]; // 40 * 6
        crt.Fill('.');

        var cycle = 0;
        var x = 1;

        foreach (var line in input.EnumerateLines())
        {
            int duration;
            int? v;

            if (line.StartsWith("noop"))
            {
                duration = 1;
                v = null;
            }
            else
            {
                duration = 2;
                v = int.Parse(line[5..]);
            }

            // Run cycles
            for (var c = 0; c < duration; c++)
            {
                cycle++;

                // Pixel position on CRT (0..239)
                var pixel = cycle - 1;

                // Horizontal position 0..39
                var col = pixel % 40;

                // Sprite covers X-1, X, X+1
                if (col >= x - 1 && col <= x + 1)
                    crt[pixel] = '#';
            }

            // Apply X update at end of instruction
            if (v is not null)
                x += v.Value;
        }

        // Build final 6 lines
        return string.Create(6 * 41, crt, (span, src) =>
        {
            var si = 0;
            var di = 0;

            for (var row = 0; row < 6; row++)
            {
                src.Slice(si, 40).CopyTo(span.Slice(di, 40));
                span[di + 40] = '\n';
                si += 40;
                di += 41;
            }
        });
    }

}

//interface IInstruction
//{
//    int Duration { get; }
//    void Execute(ref int x);
//}

//internal static Instruction
//{
//        public static iinst
//}

//internal readonly record struct Add(int v) : IInstruction
//{
//    public int Duration { get; } = 2;

//    public void Execute(ref int x)
//    {
//        x += v;
//    }
//}

//internal readonly record struct NoOp : IInstruction
//{
//    public readonly int Duration => 1;

//    public void Execute(ref int x)
//    {
//        // No Operation
//    }
//}