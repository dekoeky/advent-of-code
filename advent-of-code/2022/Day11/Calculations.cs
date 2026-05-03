using advent_of_code._2015.Day15;

namespace advent_of_code._2022.Day11;

internal static class Calculations
{
    public static long Part1(string input)
        => CalculateLevelOfMonkeyBusiness(input, 20, true);

    public static long Part2(string input)
        => CalculateLevelOfMonkeyBusiness(input, 10000, false);

    private static long CalculateLevelOfMonkeyBusiness(string input, int rounds, bool divideByThree)
    {
        var monkeys = Monkey.ParseMany(input);

        var lcm = LcmAll(monkeys.Values.Select(m => m.Divisor));
        //96577
        Debug.WriteLine($"LCM: {lcm}");

        for (var round = 1; round <= rounds; round++)
        {
            Debug.WriteLine($"==================Round {round} =============");

            foreach (var monkey in monkeys.Values)
            {
                Debug.WriteLine($"Monkey {monkey.Id}:");
                for (int i = monkey.CurrentItems.Count - 1; i >= 0; i--)
                {
                    var worry = monkey.CurrentItems[i];
                    monkey.CurrentItems.RemoveAt(i);
                    monkey.InspectionCounter++;
                    Debug.WriteLine($"  Monkey inspects an item with a worry level of {worry}.");

                    worry = monkey.Operation(worry);
                    Debug.WriteLine($"    Worry level became {worry}.");

                    if (divideByThree)
                    {
                        worry /= 3;
                        Debug.WriteLine($"    Monkey gets bored with item. Worry level is divided by 3 to {worry}.");
                    }
                    else
                    {
                        worry %= lcm;
                        Debug.WriteLine($"    Monkey gets bored with item. Worry level is modulo by {lcm} to {worry}.");
                    }

                    var testResult = monkey.IsDivisible(worry);
                    Debug.WriteLine(testResult ? "    Result is positive." : "    Result is negative.");

                    var destination = testResult ? monkey.MonkeyTrue : monkey.MonkeyFalse;
                    monkeys[destination].CurrentItems.Add(worry);
                    Debug.WriteLine($"    Item with worry level {worry} is thrown to monkey {destination}.");
                }
            }

            PrintItemsInspected(monkeys, round);
        }


        var twoMostActiveMonkeys = monkeys.Values
            .OrderByDescending(m => m.InspectionCounter)
            .Take(2)
            .ToArray();

        Debug.WriteLine($"Most Inspected: {string.Join(',', twoMostActiveMonkeys.Select(m => m.InspectionCounter))}");

        var levelOfMonkeyBusiness = twoMostActiveMonkeys
            .Product(m => (long)m.InspectionCounter);

        return levelOfMonkeyBusiness;
    }
    private static void PrintItemsInspected(Dictionary<int, Monkey> monkeys, int? round = null)
    {
        if (round is not null)
            Debug.WriteLine($"== After round {round,4} ==");

        foreach (var monkey in monkeys.Values)
            Debug.WriteLine($"Monkey {monkey.Id} inspected items {monkey.InspectionCounter} times.");

        Debug.WriteLine();
        Debug.WriteLine();
    }

    static long Gcd(long a, long b)
    {
        while (b != 0)
        {
            //var t = b;
            //b = a % b;
            //a = t;

            (a, b) = (b, a % b);
        }

        return a;
    }

    static long Lcm(long a, long b)
        => a / Gcd(a, b) * b;

    static long LcmAll(IEnumerable<long> values)
    {
        using var e = values.GetEnumerator();
        e.MoveNext();
        long result = e.Current;
        while (e.MoveNext())
            result = Lcm(result, e.Current);
        return result;
    }

}
