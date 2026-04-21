using advent_of_code.Helpers;

namespace advent_of_code._2018.Day04;

internal abstract partial record Event(DateTime TimeStamp)
{
    public static Event Parse(string input)
    {
        var parts = input.Split("] ");

        var t = DateTime.Parse(parts[0].Trim('[', ']'));
        //var t = DateTime.ParseExact(parts[0].Trim('[', ']'), "yyyy-MM-dd HH:mm", null);

        if (parts[1] == "wakes up") return new EventWakeUp(t);
        if (parts[1] == "falls asleep") return new EventFallAsleep(t);
        if (parts[1].Contains("begins shift"))
        {
            var id = int.Parse(parts[1].Split(' ')[1].Trim('#'));

            return new EventBeginShift(t, id);
        }
        throw new InvalidOperationException("Can't parse event");
    }

    public static IEnumerable<Event> ParseMany(string input)
        => SplitOn.NewLines(input).Select(Parse);
}
