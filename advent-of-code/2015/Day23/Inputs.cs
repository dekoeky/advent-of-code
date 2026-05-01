namespace AdventOfCode._2015.Day23;

public static class Inputs
{
    public const string Example =
        """
        inc a
        jio a, +2
        tpl a
        inc a
        """;

    public const string Puzzle =
        """
        jio a, +16
        inc a
        inc a
        tpl a
        tpl a
        tpl a
        inc a
        inc a
        tpl a
        inc a
        inc a
        tpl a
        tpl a
        tpl a
        inc a
        jmp +23
        tpl a
        inc a
        inc a
        tpl a
        inc a
        inc a
        tpl a
        tpl a
        inc a
        inc a
        tpl a
        inc a
        tpl a
        inc a
        tpl a
        inc a
        inc a
        tpl a
        inc a
        tpl a
        tpl a
        inc a
        jio a, +8
        inc b
        jie a, +4
        tpl a
        inc a
        jmp +2
        hlf a
        jmp -7
        """;
}