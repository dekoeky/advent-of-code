namespace advent_of_code._2020.Day25;

internal static partial class Calculations
{
    public static long Part1(long cardPublicKey, long doorPublicKey)
    {
        var loopSizeCard = GetLoopSize(7, cardPublicKey);
        var loopSizeDoor = GetLoopSize(7, doorPublicKey);

        var a = Calculate(doorPublicKey, loopSizeCard);

#if DEBUG
        var b = Calculate(cardPublicKey, loopSizeDoor);
        Assert.AreEqual(a, b);
#endif
        return a;
    }

    private static long Calculate(long subjectNumber, int loopSize)
    {
        long value = 1;

        for (var i = 0; i < loopSize; i++)
        {
            // Set the value to itself multiplied by the subject number.
            value *= subjectNumber;

            // Set the value to the remainder after dividing the value by 20201227.
            value %= 20201227;
        }

        return value;
    }


    private static int GetLoopSize(int subjectNumber, long target)
    {
        long value = 1;
        int loopSize = 0;

        while (value != target)
        {
            // Set the value to itself multiplied by the subject number.
            value *= subjectNumber;

            // Set the value to the remainder after dividing the value by 20201227.
            value %= 20201227;

            loopSize++;
        }

        return loopSize;
    }
}
