namespace advent_of_code._2023.Day07;

internal class ResultSorter(string strengths) : Comparer<(string Cards, int Bid, Result Result)>
{
    public override int Compare((string Cards, int Bid, Result Result) x, (string Cards, int Bid, Result Result) y)
    {
        var result = x.Result.CompareTo(y.Result);

        if (result != 0)
            return result;

        for (var i = 0; i < 5; i++)
        {
            var rankX = strengths.IndexOf(x.Cards[i]);
            var rankY = strengths.IndexOf(y.Cards[i]);

            result = rankX.CompareTo(rankY);
            if (result != 0) break;
        }

        return result;
    }
}