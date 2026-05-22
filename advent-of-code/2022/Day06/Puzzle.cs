namespace advent_of_code._2022.Day06;

/// <summary>
/// Year 2022 Day 06 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2022/day/6"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DataRow("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [DataRow("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [DataRow("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [DataRow("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [DataRow("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Part1Examples(string input, int expected)
    {
        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input);

        // Assert
        Assert.AreEqual(1175, result);
    }

    [TestMethod]
    [DataRow("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [DataRow("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [DataRow("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [DataRow("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [DataRow("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void Part2Examples(string input, int expected)
    {
        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part2(input);

        // Assert
        Assert.AreEqual(3217, result);
    }
}