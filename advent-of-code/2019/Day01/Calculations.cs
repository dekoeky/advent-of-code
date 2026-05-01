namespace AdventOfCode._2019.Day01;

internal static class Calculations
{
    public static int FuelRequired(int mass)
    {
        // Fuel required to launch a given module is based on its mass. 
        // Specifically, to find the fuel required for a module, take its mass, divide by three, round down, and subtract 2.

        return (mass / 3) - 2;
    }

    public static int FuelRequiredRecursive(int mass)
    {
        var fuel = FuelRequired(mass);

        var additionalMass = fuel;

        while (additionalMass > 0)
        {
            var additionalFuel = Math.Max(0, FuelRequired(additionalMass));

            fuel += additionalFuel;

            additionalMass = additionalFuel;
        }

        return fuel;
    }
}