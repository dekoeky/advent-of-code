namespace AdventOfCode._2015.Day01;

internal static class Calculations
{
    private const char floorUp = '(';
    private const char floorDown = ')';

    public static int FinalFloor(ReadOnlySpan<char> input)
    {
        checked // prevent overflow
        {
            int floor = 0;

            foreach (var c in input)
                if (c == floorUp)
                    floor++;
                else if (c == floorDown)
                    floor--;
                else throw new InvalidOperationException("Unexpected character");

            return floor;
        }
    }
    public static int BasementEnteredInStep(ReadOnlySpan<char> input)
    {
        checked // prevent overflow
        {
            int floor = 0;

            for (var i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case floorUp:
                        floor++;
                        break;
                    case floorDown:
                        floor--;
                        break;
                    default:
                        throw new InvalidOperationException("Unexpected character");
                }

                if (floor < 0) return i + 1; // +1 because first step, is index 0, is step 1
            }

            return floor;
        }
    }
}