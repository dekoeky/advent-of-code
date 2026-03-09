namespace advent_of_code._2015.Day03;

internal static class Calculations
{
    public static int Perform(ReadOnlySpan<char> moves)
    {
        var house = new LatLon();
        var visitCount = new Dictionary<LatLon, int>
        {
            { house, 1 }
        };

        foreach (var move in moves)
        {
            house.Move(move);

            if (visitCount.TryGetValue(house, out int value))
                visitCount[house] = ++value;
            else
                visitCount.Add(house, 1);
        }

        return visitCount.Keys.Count;
    }

    public static int Perform2(ReadOnlySpan<char> moves)
    {
        var santa = new LatLon();
        var roboSanta = new LatLon();
        var visitCount = new Dictionary<LatLon, int>
        {
            { santa, 2 }
        };

        for (var i = 0; i < moves.Length; i++)
        {
            var move = moves[i];

            if (i % 2 == 0)
                Move(ref santa, move);
            else
                Move(ref roboSanta, move);
        }

        return visitCount.Keys.Count;

        void Move(ref LatLon pos, char move)
        {
            pos.Move(move);

            if (visitCount.TryGetValue(pos, out int value))
                visitCount[pos] = ++value;
            else
                visitCount.Add(pos, 1);
        }
    }
}