namespace advent_of_code._2018.Day11;

internal static class Calculations
{
    public static string Part1(int gridSerialNumber)
    {
        var grid = BuildPowerLevelGrid(gridSerialNumber);

        var (x, y) = GetMaxOfSize(grid, 3, out _);

        return $"{x},{y}";
    }

    private static int[,] BuildPowerLevelGrid(int gridSerialNumber)
    {
        var grid = new int[301, 301];

        // Calculate power levels
        for (var y = 1; y <= 300; y++)
            for (var x = 1; x <= 300; x++)
                grid[y, x] = PowerLevel(x, y, gridSerialNumber);

        return grid;
    }

    public static string Part2(int gridSerialNumber)
    {
        var grid = BuildPowerLevelGrid(gridSerialNumber);

        // Critical for performance of part2
        var sat = BuildSummedAreaTable(grid);

        var bestX = 0;
        var bestY = 0;
        var bestSize = 0;
        var bestPower = int.MinValue;

        for (var size = 1; size <= 300; size++)
        {
            var limit = 301 - size;

            for (var y = 1; y < limit; y++)
                for (var x = 1; x < limit; x++)
                {
                    var sum = SquareSum(sat, y, x, size);
                    if (sum > bestPower)
                    {
                        bestPower = sum;
                        bestX = x;
                        bestY = y;
                        bestSize = size;
                    }
                }
        }

        return $"{bestX},{bestY},{bestSize}";
    }

    private static int Sum(int[,] values, int x, int y, int size)
    {
        var sum = 0;

        for (var r = y; r < y + size; r++)
            for (var c = x; c < x + size; c++)
                sum += values[r, c];

        return sum;
    }

    public static int[,] BuildSummedAreaTable(int[,] grid)
    {
        var sat = new int[301, 301];

        for (int y = 1; y <= 300; y++)
        {
            var rowSum = 0;
            for (int x = 1; x <= 300; x++)
            {
                rowSum += grid[y, x];
                sat[y, x] = sat[y - 1, x] + rowSum;
            }
        }

        return sat;
    }

    public static int SquareSum(int[,] sat, int row, int col, int size)
    {
        int row2 = row + size - 1;
        int col2 = col + size - 1;

        return sat[row2, col2]
             - sat[row - 1, col2]
             - sat[row2, col - 1]
             + sat[row - 1, col - 1];
    }

    private static (int X, int Y) GetMaxOfSize(int[,] grid, int size, out int max)
    {
        max = int.MinValue;
        var maxPos = (X: -1, Y: -1);

        var h = grid.GetLength(0);
        var w = grid.GetLength(1);

        for (var y = 1; y < h - size; y++)
            for (var x = 1; x < w - size; x++)
            {
                var sum = Sum(grid, x, y, size);
                if (sum <= max)
                    continue;

                max = sum;
                maxPos = (X: x, Y: y);
            }

        //Debug.WriteLine($"Max: {max}");

        return maxPos;
    }

    public static int PowerLevel(int x, int y, int gridSerialNumber)
    {
        var rackId = x + 10;
        //Debug.WriteLine($"The rack ID is {x} + 10 = {rackId}");

        var powerLevel = rackId * y;
        //Debug.WriteLine($"The power level starts at {rackId} * {y} = {powerLevel}");

        //Debug.Write($"Adding the serial number produces {powerLevel} + {gridSerialNumber} = ");
        powerLevel += gridSerialNumber;
        //Debug.WriteLine(powerLevel);

        //Debug.Write($"Multiplying by the rack ID produces {powerLevel} * {rackId} = ");
        powerLevel *= rackId;
        //Debug.WriteLine(powerLevel);

        //Debug.Write($"The hundreds digit of {powerLevel} is ");
        powerLevel = (powerLevel / 100) % 10;
        //Debug.WriteLine(powerLevel);

        //Debug.Write($"Subtracting 5 produces {powerLevel} - 5 = ");
        powerLevel -= 5;
        //Debug.WriteLine(powerLevel);

        return powerLevel;
    }
}