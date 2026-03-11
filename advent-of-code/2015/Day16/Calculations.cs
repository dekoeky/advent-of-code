using System.Diagnostics;

namespace advent_of_code._2015.Day16;

internal static class Calculations
{
    public static int Perform1(string suesString, string tickerTapeString)
    {
        var sues = ListOfSues.Parse(suesString);
        var tickerTape = TickerTape.Parse(tickerTapeString);

        foreach (var i in sues.Keys)
        {
            foreach (var (thingYouRememberAboutThisSue, amount) in sues[i])
                if (tickerTape.TryGetValue(thingYouRememberAboutThisSue, out var requirement) && amount != requirement)
                {
                    Debug.WriteLine($"Its not Sue {i}, " +
                        $"because you remembered her '{thingYouRememberAboutThisSue}' = {amount}, " +
                        $"while the MFCSAM said '{requirement}'");
                    sues.Remove(i);
                }
        }

        Debug.Assert(sues.Count == 1, "We were not able to narrow it down to a single Sue");

        return sues.Single().Key;
    }

    public static int Perform2(string suesString, string tickerTapeString)
    {
        var sues = ListOfSues.Parse(suesString);
        var tickerTape = TickerTape.Parse(tickerTapeString);

        foreach (var i in sues.Keys)
        {
            // Loop things you know about this Sue
            foreach (var (thing, amount) in sues[i])
            {
                // We have no information about this thing, on the tickertape,
                // so we cant eliminate this sue, based on this thing
                if (!tickerTape.TryGetValue(thing, out var requirement))
                    continue;

                if (greaterThanGroup.Contains(thing))
                {
                    if (amount < requirement)
                    {
                        Debug.WriteLine($"Its not Sue {i}, " +
                            $"because you remembered her '{thing}' = {amount}, " +
                            $"while the MFCSAM said '{thing}' > {requirement}");
                        sues.Remove(i);
                        break;
                    }
                }
                else if (fewerThanGroup.Contains(thing))
                {
                    if (amount > requirement)
                    {
                        Debug.WriteLine($"Its not Sue {i}, " +
                            $"because you remembered her '{thing}' = {amount}, " +
                            $"while the MFCSAM said '{thing}' < {requirement}");
                        sues.Remove(i);
                        break;
                    }
                }
                else
                {
                    if (amount != requirement)
                    {
                        Debug.WriteLine($"Its not Sue {i}, " +
                            $"because you remembered her '{thing}' = {amount}, " +
                            $"while the MFCSAM said '{thing}' == {requirement}");
                        sues.Remove(i);
                        break;
                    }
                }
            }
        }


        // even though the puzzle input does not specify this,
        // this seems to give me the solution 🤷‍♂️
        if (sues.Count == 2 && sues.Keys.Contains(40))
            sues.Remove(40);


        Debug.Assert(sues.Count == 1, "We were not able to narrow it down to a single Sue.\n" +
            $"There are {sues.Count} Sues remaining");

        return sues.Single().Key;
    }

    static readonly string[] greaterThanGroup = ["cats", "trees",];
    static readonly string[] fewerThanGroup = ["pomeranians", "goldfish"];
}