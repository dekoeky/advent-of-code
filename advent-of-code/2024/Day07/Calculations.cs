namespace advent_of_code._2024.Day07;

public static class Calculations
{
    private static readonly char[] Operators = ['+', '*'];
    public static IEnumerable<char> GetPossibleOperators()
    {
        foreach (var @operator in Operators)
            yield return @operator;
    }

    public static IEnumerable<char[]> GetPossibleOperators(int level)
    {
        if (level == 1)
        {
            foreach (var @operator in Operators)
                yield return [@operator];
            yield break;
        }

        var operators = new char[level];

        foreach (var primaryOperator in Operators)
        {
            operators[0] = primaryOperator;
            foreach (var secondaryOperators in GetPossibleOperators(level - 1))
            {
                Array.Copy(secondaryOperators, 0, operators, 1, level - 1);
                yield return operators;
            }
        }
    }

    public static bool IsPossible(Equation equation)
    {
        var possibleOperators = GetPossibleOperators(equation.Values.Length - 1);

        return possibleOperators.Any(o => IsValid(equation, o));
    }

    public static bool IsValid(Equation equation, char[] operators)
    {
        var result = equation.Values[0];

        for (var i = 0; i < operators.Length; i++)
        {
            var o = operators[i];
            var v = equation.Values[i + 1];

            result = o switch
            {
                '+' => result + v,
                '*' => result * v,
                _ => throw new InvalidOperationException(),
            };
        }

        return result == equation.TestValue;
    }

}