namespace AdventOfCode._2016.Day01;

internal static class RotationExtensions
{
    extension(Rotation)
    {
        public static Rotation Parse(char s) => s switch
        {
            'R' => Rotation.Right,
            'L' => Rotation.Left,
            _ => throw new NotImplementedException(),
        };
    }
}
