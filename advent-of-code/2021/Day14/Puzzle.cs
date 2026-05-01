namespace AdventOfCode._2021.Day14;

/// <summary>
/// Year 2021 Day 14 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2021/day/14"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void NoOverlappingKeys()
    {
        // Arrange
        HashSet<int> keys = [];

        // Act & Assert
        for (char a = 'A'; a <= 'Z'; a++)
            for (char b = 'A'; b <= 'Z'; b++)
            {
                var key = InsertionRules.CreateKey(a, b);

                if (!keys.Add(key))
                    Assert.Fail($"Duplicate key {key}");

                var expanded = InsertionRules.Expand(key);

                Assert.AreEqual(a, expanded.a);
                Assert.AreEqual(b, expanded.b);
            }
    }

    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;
        var steps = 10;

        // Act
        var result = Calculations.Execute(input, steps);

        // Assert
        Assert.AreEqual(1588, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var steps = 10;

        // Act
        var result = Calculations.Execute(input, steps);

        // Assert
        Assert.AreEqual(3408, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;
        var steps = 40;

        // Act
        var result = Calculations.Execute(input, steps);

        // Assert
        Assert.AreEqual(2188189693529, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var steps = 40;

        // Act
        var result = Calculations.Execute(input, steps);

        // Assert
        Assert.AreEqual(3724343376942, result);
    }
}