using AdventOfCode._2016.Day10.Models;

namespace AdventOfCode._2016.Day10;

internal static class Calculations
{
    public static int Part1(string input)
    {
        var parsed = ParseInput(input);

        var (part1, _) = Execute(parsed);

        return part1;
    }

    public static int Part2(string input)
    {
        var parsed = ParseInput(input);

        var (_, outputs) = Execute(parsed);

        var part2 =
           outputs.GetValueOrDefault(0) *
           outputs.GetValueOrDefault(1) *
           outputs.GetValueOrDefault(2);

        return part2;
    }

    private static ParsedInput ParseInput(string input)
    {
        var values = new List<ValueInstruction>();
        var rules = new List<BotRuleInstruction>();

        foreach (var line in SplitOn.NewLines(input))
        {
            var parts = line.Split(' ');

            if (parts[0] == "value")
            {
                int value = int.Parse(parts[1]);
                int bot = int.Parse(parts[5]);
                values.Add(new ValueInstruction(value, bot));
            }
            else if (parts[0] == "bot")
            {
                int botId = int.Parse(parts[1]);

                var lowType = parts[5] == "bot" ? TargetType.Bot : TargetType.Output;
                int lowId = int.Parse(parts[6]);

                var highType = parts[10] == "bot" ? TargetType.Bot : TargetType.Output;
                int highId = int.Parse(parts[11]);

                rules.Add(new BotRuleInstruction(
                    botId,
                    new Target(lowType, lowId),
                    new Target(highType, highId)
                ));
            }
        }

        return new ParsedInput(values, rules);
    }

    static (int part1, Dictionary<int, int> outputs) Execute(ParsedInput input)
    {
        var bots = new Dictionary<int, List<int>>();
        var outputs = new Dictionary<int, int>();
        var rules = input.Rules.ToDictionary(r => r.BotId);

        // Initialize bots with values
        foreach (var v in input.Values)
        {
            if (!bots.ContainsKey(v.BotId))
                bots[v.BotId] = [];

            bots[v.BotId].Add(v.Value);
        }

        // Queue of bots ready to act
        var queue = new Queue<int>(
            bots.Where(kv => kv.Value.Count == 2).Select(kv => kv.Key)
        );

        int part1 = -1;

        while (queue.Count > 0)
        {
            int bot = queue.Dequeue();
            var chips = bots[bot];

            if (chips.Count < 2)
                continue;

            chips.Sort();
            int low = chips[0];
            int high = chips[1];

            // Part 1 condition
            if (low == 17 && high == 61)
                part1 = bot;

            var rule = rules[bot];

            // Deliver low
            Deliver(rule.Low, low, bots, outputs, queue);

            // Deliver high
            Deliver(rule.High, high, bots, outputs, queue);

            // Clear bot
            bots[bot].Clear();
        }

        return (part1, outputs);
    }

    static void Deliver(
        Target target,
        int value,
        Dictionary<int, List<int>> bots,
        Dictionary<int, int> outputs,
        Queue<int> queue)
    {
        if (target.Type == TargetType.Bot)
        {
            if (!bots.ContainsKey(target.Id))
                bots[target.Id] = [];

            bots[target.Id].Add(value);

            if (bots[target.Id].Count == 2)
                queue.Enqueue(target.Id);
        }
        else
        {
            outputs[target.Id] = value;
        }
    }
}