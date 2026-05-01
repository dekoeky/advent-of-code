namespace AdventOfCode._2016.Day21.Operations;

internal abstract record Operation
{
    public static Operation Parse(string input) =>
        SwapPositionOperation.TryParse(input, out var op) ? op :
        SwapLetterOperation.TryParse(input, out op) ? op :
        RotateStepsOperation.TryParse(input, out op) ? op :
        RotateBasedOnLetterOperation.TryParse(input, out op) ? op :
        ReversePositionsOperation.TryParse(input, out op) ? op :
        MovePositionOperation.TryParse(input, out op) ? op :
            throw new NotImplementedException();

    public abstract void Apply(Span<char> password);
    public abstract void Revert(Span<char> scrambled);
}
