namespace advent_of_code._2025.Day10.Utilities;

internal static class BinaryStringFormatting
{
    public static string ToBinaryString(this int value) => Convert.ToString(value, 2);
    public static string ValueAndBinary(this int value, int binaryPadLength)
    {
        var binary = value.ToBinaryString().PadLeft(binaryPadLength, '0');
        var integerLength = LengthOfMaximalRepresentableNumber(binaryPadLength);
        var integer = value.ToString().PadLeft(integerLength);
        return $"{integer}[{binary}]";
    }

    private static int LengthOfMaximalRepresentableNumber(int numberOfBits)
    {
        // The maximum value represented by this amount of bits
        // Is the value represented by a single 1 bit, one place more significant, minus 1
        var maxVal = (int)Math.Pow(2, numberOfBits + 1) - 1;

        return (int)Math.Floor(Math.Log10(maxVal)) + 1;
    }
}