namespace advent_of_code._2024.Day09;

internal static class Calculations
{
    public static long Part1(ReadOnlySpan<char> input)
    {
        var disk = Parse(input);

        CompactV1(disk);

        return CheckSum(disk);
    }

    public static long Part2(ReadOnlySpan<char> input)
    {
        var disk = Parse(input);

        CompactV2(disk);

        return CheckSum(disk);
    }

    private static Span<int> Parse(ReadOnlySpan<char> input)
    {
        var totalLength = GetTotalDiskLength(input);
        Span<int> disk = new int[totalLength];
        var i = 0;
        var isFile = true;
        var fileId = 0;
        foreach (var c in input)
        {
            var l = c - '0';
            var block = disk.Slice(i, l);
            if (isFile)
                block.Fill(fileId++);
            else
                block.Fill(-1);
            i += l;
            isFile = !isFile;
        }

        return disk;
    }

    private static int GetTotalDiskLength(ReadOnlySpan<char> input)
    {
        var totalLength = 0;

        foreach (var c in input)
        {
            totalLength += c - '0';
        }

        return totalLength;
    }

    private static void CompactV1(Span<int> disk)
    {
        var i = disk.IndexOf(-1);
        var j = disk.LastIndexOfAnyExcept(-1);
        Print(disk);
        while (j > i)
        {
            if (disk[i] != -1) break;
            if (disk[j] == -1) break;

            (disk[i], disk[j]) = (disk[j], disk[i]);
            Print(disk);

            while (i < j)
                if (disk[++i] == -1) break;

            while (i < j)
                if (disk[--j] != -1) break;
        }
    }

    private static void CompactV2(Span<int> disk)
    {
        for (var fileId = MaxFileId(disk); fileId >= 0; fileId--)
        {
            if (!TryFindFile(disk, fileId, out var fileRange))
                continue;

            var fileSpan = disk[fileRange];

            if (!TryFindSpace(disk, fileSpan.Length, fileRange.Start.Value, out var emptyRange))
                continue;

            fileSpan.CopyTo(disk[emptyRange]);
            fileSpan.Fill(-1);
        }
    }

    private static int MaxFileId(ReadOnlySpan<int> input)
    {
        var max = int.MinValue;

        foreach (var value in input)
            if (value > max)
                max = value;

        return max;
    }

    private static bool TryFindFile(ReadOnlySpan<int> disk, int fileId, out Range range)
    {
        var end = disk.LastIndexOf(fileId);
        var start = disk.IndexOf(fileId);

        if (start == -1 || end == -1)
        {
            range = default;
            return false;
        }

        range = new Range(start, end + 1);
        return true;
    }

    private static bool TryFindSpace(ReadOnlySpan<int> disk, int size, int before, out Range range)
    {
        int runStart = -1;
        int runLength = 0;

        for (int i = 0; i < before; i++)
        {
            if (disk[i] == -1)
            {
                if (runLength == 0)
                    runStart = i;

                if (++runLength == size)
                {
                    range = new Range(runStart, runStart + size);
                    return true;
                }
            }
            else
            {
                runLength = 0;
            }
        }

        range = default;
        return false;
    }

    private static void Print(ReadOnlySpan<int> values)
    {
        // Can only print values from 0-9
        if (values.ContainsAnyExceptInRange(-1, 9))
            return;

        foreach (var v in values)
            Debug.Write(v == -1 ? '.' : (char)(v + '0'));

        Debug.WriteLine();
    }

    private static long CheckSum(Span<int> disk)
    {
        long sum = 0;

        checked
        {
            var last = -1;
            for (var j = 0; j < disk.Length; j++)
            {
                var k = disk[j];
                if (k != -1)
                {
                    sum += j * disk[j];
                }
            }
        }

        return sum;
    }
}