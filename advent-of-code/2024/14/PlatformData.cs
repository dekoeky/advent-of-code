using System.Text;

namespace advent_of_code._2024._14;

public class PlatformData(char[/* ROW */, /* COLUMN */] data) : IEquatable<PlatformData>
{
    private const char RoundedRock = 'O';
    private const char CubeShapedRock = '#';
    private const char EmptySpace = '.';

    private readonly char[/* ROW */, /* COLUMN */] _data = data;
    public PlatformData Duplicate() => new(_data.Duplicate());
    public static PlatformData FromFile(string file)
    {
        var lines = File.ReadAllLines(file);
        var R = lines.Length;
        var C = lines.FirstOrDefault()?.Length ?? 0;

        var data = new char[R, C];
        for (var r = 0; r < R; r++)
            for (var c = 0; c < C; c++)
                data[r, c] = lines[r][c];

        return new PlatformData(data);
    }
    public void Cycle(int N)
    {
        for (var i = 0; i < N; i++)
            Cycle();
    }
    public void Cycle()
    {
        ShiftNorth();
        ShiftWest();
        ShiftSouth();
        ShiftEast();
    }

    public void Shift(ShiftDirection direction)
    {
        switch (direction)
        {
            case ShiftDirection.N: ShiftNorth(); break;
            case ShiftDirection.S: ShiftSouth(); break;
            case ShiftDirection.E: ShiftEast(); break;
            case ShiftDirection.W: ShiftWest(); break;
            default: throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    private void ShiftNorth()
    {
        //for (var c = 0; c < Columns; c++) ShiftNorth(c);
        Parallel.For(0, Columns - 1, ShiftNorth);
    }

    private void ShiftNorth(int c)
    {
        var dots = 0;

        for (var r = 0; r < Rows; r++)
        {
            var element = _data[r, c];

            switch (element)
            {
                case EmptySpace:
                    dots++;
                    break;
                case CubeShapedRock:
                    dots = 0;
                    break;
                case RoundedRock when dots > 0:
                    _data[r, c] = EmptySpace;
                    _data[r - dots, c] = RoundedRock;
                    break;
            }
        }
    }

    private void ShiftSouth()
    {
        //for (var c = 0; c < Columns; c++) ShiftSouth(c);
        Parallel.For(0, Columns - 1, ShiftSouth);
    }

    private void ShiftSouth(int c)
    {
        var dots = 0;

        for (var r = Rows - 1; r >= 0; r--)
        {
            var element = _data[r, c];

            switch (element)
            {
                case EmptySpace:
                    dots++;
                    break;
                case CubeShapedRock:
                    dots = 0;
                    break;
                case RoundedRock when dots > 0:
                    _data[r, c] = EmptySpace;
                    _data[r + dots, c] = RoundedRock;
                    break;
            }
        }
    }

    private void ShiftWest()
    {
        //for (var r = 0; r < Rows; r++) ShiftWest(r);
        Parallel.For(0, Rows - 1, ShiftWest);
    }

    private void ShiftWest(int r)
    {
        var dots = 0;

        for (var c = 0; c < Columns; c++)
        {
            var element = _data[r, c];

            switch (element)
            {
                case EmptySpace:
                    dots++;
                    break;
                case CubeShapedRock:
                    dots = 0;
                    break;
                case RoundedRock when dots > 0:
                    _data[r, c] = EmptySpace;
                    _data[r, c - dots] = RoundedRock;
                    break;
            }
        }
    }

    private void ShiftEast()
    {
        //for (var r = 0; r < Rows; r++) ShiftEast(r);

        Parallel.For(0, Rows - 1, ShiftEast);
    }

    private void ShiftEast(int r)
    {
        var dots = 0;

        for (var c = Columns - 1; c >= 0; c--)
        {
            var element = _data[r, c];

            switch (element)
            {
                case EmptySpace:
                    dots++;
                    break;
                case CubeShapedRock:
                    dots = 0;
                    break;
                case RoundedRock when dots > 0:
                    _data[r, c] = EmptySpace;
                    _data[r, c + dots] = RoundedRock;
                    break;
            }
        }
    }


    public int Rows => _data.GetLength(0);
    public int Columns => _data.GetLength(1);

    public int GetLoad()
    {
        var load = 0;
        for (var r = 0; r < Rows; r++)
        {
            var loadForThisRow = Rows - r;

            for (var c = 0; c < Columns; c++)
                if (_data[r, c] == RoundedRock)
                    load += loadForThisRow;
        }

        return load;
    }

    public bool Equals(PlatformData? other)
    {
        if (other is null) return false;

        if (other.Rows != Rows || other.Columns != Columns) return false;

        for (var r = 0; r < Rows; r++)
            for (var c = 0; c < Columns; c++)
                if (other._data[r, c] != _data[r, c])
                    return false;

        return true;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (var r = 0; r < Rows; r++)
        {
            for (var c = 0; c < Columns; c++)
                sb.Append(_data[r, c]);
            if (r != Rows - 1)
                sb.AppendLine();
        }
        return sb.ToString();
    }
}