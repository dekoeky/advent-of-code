namespace advent_of_code._2017.Day25;

internal static class Calculations
{
    public static int Execute(string input)
    {
        var puzzleInput = PuzzleInput.Parse(input);

        var state = puzzleInput.States[puzzleInput.BeginState];
        var cursor = 0;
        Dictionary<int, int> tape = [];

        for (var step = 0; step < puzzleInput.DiagnosticStep; step++)
        {
            var currentValue = tape.GetValueOrDefault(cursor, 0);

            var action = state.Parts[currentValue];


            tape[cursor] = action.WriteValue;
            cursor += action.Left ? -1 : +1;
            state = puzzleInput.States[action.ContinueState];
        }

        return tape.Values.Count(v => v == 1);
    }
}
