namespace AdventOfCode._2022.Day07;

internal static class Calculations
{
    public static long Part1(ReadOnlySpan<char> input, long atMost = 100000)
    {
        var fileSizes = GetFileSizes(input);
        var dirSizes = GetDirSizes(fileSizes);

        return dirSizes.Where(kv => kv.Value <= atMost).Sum(kv => kv.Value);
    }

    public static long Part2(ReadOnlySpan<char> input, long totalSpace = 70000000, long neededSpace = 30000000)
    {
        var fileSizes = GetFileSizes(input);
        var dirSizes = GetDirSizes(fileSizes);
        var used = dirSizes["/"];
        var unUsed = totalSpace - used;

        if (neededSpace < unUsed)
            return 0;

        var toDelete = neededSpace - unUsed;

        return dirSizes.Where(kv => kv.Value >= toDelete).Min(kv => kv.Value);
    }

    private static Dictionary<string, long> GetFileSizes(ReadOnlySpan<char> input)
    {
        var cd = "";
        Dictionary<string, long> files = [];

        foreach (var line in input.EnumerateLines())
        {
            // Ignore ls input
            if (line.StartsWith($"$ ls"))
                continue;

            // Ignore dirs, we will distil them from the files
            else if (line.StartsWith("dir"))
                continue;

            // Use cd input to update current dir
            else if (line.StartsWith("$ cd"))
            {
                // Grab the argument
                var arg = line[5..];

                // If '..' -> remove the last    subdir/   part
                if (arg.SequenceEqual(".."))
                    cd = cd[..(cd.LastIndexOf('/', cd.Length - 2) + 1)];

                // If '/' -> go to root dir /
                else if (arg.SequenceEqual("/"))
                    cd = "/";

                // If any other, move into subdir (and close with /)
                else
                    cd += $"{arg}/";


                continue;
            }

            // This will be file size output
            else
            {
                var space = line.IndexOf(' ');
                // Part before space is size
                var size = long.Parse(line[..space]);

                // Part after space is file NAME (not path)
                var fileName = line[(space + 1)..];

                // File path depends on current dir
                var filePath = $"{cd}{fileName}";

                // Store this file size
                files.Add(filePath, size);
            }
        }

        return files;
    }


    private static Dictionary<string, long> GetDirSizes(Dictionary<string, long> fileSizes)
    {
        var dirs = new Dictionary<string, long>();

        foreach (var (filePath, fileSize) in fileSizes)
        {
            var dir = filePath;
            do
            {
                // Remove the filename (first loop)
                // or remove the previously deepest subdir (next loops)
                dir = dir[..(dir.LastIndexOf('/', dir.Length - 2) + 1)];

                // Update total dir size for this level
                if (dirs.TryGetValue(dir, out long dirSize))
                    dirs[dir] = dirSize + fileSize;
                else
                    dirs.Add(dir, fileSize);

                // Keep doing this for parent directories too
            } while (dir.Length > 1);
        }

        return dirs;
    }
}