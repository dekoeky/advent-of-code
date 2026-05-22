namespace advent_of_code._2018.Day04;

internal record EventBeginShift(DateTime TimeStamp, int GuardId) : Event(TimeStamp);
