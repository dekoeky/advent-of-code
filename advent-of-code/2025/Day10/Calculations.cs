using advent_of_code._2025.Day10.Models;
using advent_of_code._2025.Day10.Utilities;
using advent_of_code.Helpers;
using System.Diagnostics;

namespace advent_of_code._2025.Day10;

public static class Calculations
{
    private const int DefaultState = 0;

    public static long FewestButtonPressesRequired(string manual)
    {
        // The manual describes one machine per line.
        var machines = SplitOn.NewLines(manual)
            .Select(Machine.Parse)
            .ToArray();

        var sum = 0L;

        foreach (var machine in machines)
        {
            var minMoves = MinMoves(machine);
            sum += minMoves;
            Debug.WriteLine($"Min Moves {minMoves} for {machine.String}");
            Debug.WriteLine("");
        }

        return sum;
    }

    public static int MinMoves(Machine machine)
    {
        Print(machine);

        // Helper for formatting
        var b = machine.Diagram.String.Length - 2; // -2 for brackets

        // edge case
        if (machine.Diagram.Value == DefaultState) return 0;

        List<(int StartState, ButtonWiring[] ButtonsPressed)> starts = [(DefaultState, [])];

        // Assume there is always a solution
        for (var i = 0; i < starts.Count; i++)
        {
            var (startState, buttonsPressed) = starts[i];

            Debug.WriteLine($"   Starting from {startState} ({Convert.ToString(startState, 2)})");

            // Try all the buttons (including the one we just pressed, to make things easier
            foreach (var button in machine.Buttons)
            {
                // Calculate the new state we get, by starting from the start State, and pressing this button
                var newState = startState ^ button.Value;

                // The number of buttons pressed is now one more than the start situation
                var numberOfButtonsPressed = buttonsPressed.Length + 1;


                // If the new state equals the indicator light diagram, we found the solution
                if (newState == machine.Diagram.Value)
                {
                    Debug.WriteLine(button.String);
                    Debug.WriteLine($"{startState.ValueAndBinary(b)} => {newState.ValueAndBinary(b)} (by pressing {button.Value.ValueAndBinary(b)}) WINNER WINNER, CHICKEN DINER");
                    //var buttonsPressedIncludingNewButton = buttonsPressed.Append(button.Value).ToArray();
                    return numberOfButtonsPressed;
                }
                // We did not find the solution by pressing the last button

                bool newStateFound = false;

                // If we did not yet land on this state by any previous combinations, we store it
                if (starts.All(s => s.StartState != newState))
                {
                    newStateFound = true;
                    var allPressedButtons = buttonsPressed.Append(button).ToArray();
                    starts.Add((newState, allPressedButtons));
                }

                Debug.WriteLine($"{startState.ValueAndBinary(b)} => {newState.ValueAndBinary(b)} (by pressing {button.Value.ValueAndBinary(b)}) {(newStateFound ? "NEW" : "   ")} button {button.String}");
                //Debug.WriteLine($"Pressing button {button.String}[{button.Value.ToBinaryString()}] brings the state from {Convert.ToString(startState, 2)} to {Convert.ToString(newState, 2)}");

            }
            Debug.WriteLine("");
        }
        Debug.WriteLine("************");
        throw new InvalidOperationException("should not end up here");
    }

    private static void Print(Machine machine)
    {
        Debug.WriteLine($"Diagram: {machine.Diagram.String} -> {machine.Diagram.Value} -> {machine.Diagram.Value.ToBinaryString()}");
        Debug.WriteLine($"Button Wirings:");
        foreach (var buttonWiring in machine.Buttons)
            Debug.WriteLine($"    {buttonWiring.String} -> {buttonWiring.Value} -> {buttonWiring.Value.ToBinaryString()}");
    }
}