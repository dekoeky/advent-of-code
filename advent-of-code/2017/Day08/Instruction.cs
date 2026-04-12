namespace advent_of_code._2017.Day08;

record Instruction(string Register, string Manipulation, int Delta, string IfRegister, string IfCheck, int IfValue)
{

    public static Instruction Parse(string input)
    {
        var parts = input.Split(' ');

        var register = parts[0];
        var manipulation = parts[1];
        var delta = int.Parse(parts[2]);
        Debug.Assert(parts[3] == "if");
        var ifRegister = parts[4];
        var ifCheck = parts[5];
        var ifValue = int.Parse(parts[6]);


        return new Instruction(
            register,
            manipulation,
            delta,
            ifRegister,
            ifCheck,
            ifValue
            );
    }
}