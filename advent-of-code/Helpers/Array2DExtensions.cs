namespace advent_of_code.Helpers;

public static class Array2DExtensions
{
    public static TOut[,] CreateEqualSizeArray<TOut>(this Array data) => 
        new TOut[data.GetLength(0), data.GetLength(1)];
}