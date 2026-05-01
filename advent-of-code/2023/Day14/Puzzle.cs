namespace AdventOfCode._2023.Day14.puzzle1;

/// <seealso href="https://adventofcode.com/2023/day/14"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow(Inputs.Example)]
    [DataRow(Inputs.ExampleShifted)]
    public void ReadAndToString(string input)
    {
        // Arrange
        var expected = input;

        // Act
        var actual = PlatformData.Parse(input).ToString();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        const int expectedLoad = 136;
        var exampleInput = PlatformData.Parse(Inputs.Example);
        var exampleShifted = PlatformData.Parse(Inputs.ExampleShifted);

        // Act
        var shifted = exampleInput.Duplicate();
        shifted.Shift(ShiftDirection.N);

        var loadFromShiftedInput = exampleShifted.GetLoad();
        var actualLoad = shifted.GetLoad();

        // Assert
        Assert.AreEqual(expectedLoad, loadFromShiftedInput);
        Assert.AreEqual(expectedLoad, actualLoad);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = PlatformData.Parse(Inputs.Puzzle);

        // Act
        input.Shift(ShiftDirection.N);
        var load = input.GetLoad();

        // Assert
        Assert.AreEqual(110407, load);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        const int expectedLoad = 64;
        const int cycles = 1000000000;
        var workData = PlatformData.Parse(Inputs.Example);
        var exampleCycled1 = PlatformData.Parse(Inputs.ExampleAfterCycle1);
        var exampleCycled2 = PlatformData.Parse(Inputs.ExampleAfterCycle2);
        var exampleCycled3 = PlatformData.Parse(Inputs.ExampleAfterCycle3);

        // Act
        workData.Cycle();
        var cycled1 = workData.Duplicate();
        workData.Cycle();
        var cycled2 = workData.Duplicate();
        workData.Cycle();
        var cycled3 = workData.Duplicate();

        workData.Cycle(cycles - 3);
        var actualLoad = workData.GetLoad();

        // Assert
        Assert.AreEqual(exampleCycled1.ToString(), cycled1.ToString());
        Assert.AreEqual(exampleCycled2.ToString(), cycled2.ToString());
        Assert.AreEqual(exampleCycled3.ToString(), cycled3.ToString());
        Assert.AreEqual(expectedLoad, actualLoad);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        const int cycles = 1000000000;
        var data = PlatformData.Parse(Inputs.Puzzle);

        // Act
        data.Cycle(cycles);
        var load = data.GetLoad();

        // Assert
        Assert.AreEqual(-1, load);
    }
}