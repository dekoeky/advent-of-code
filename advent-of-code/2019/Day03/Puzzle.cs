namespace advent_of_code._2019.Day03;

/// <summary>
/// Year 2019 Day 03 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2019/day/3"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    [DynamicData(nameof(Part1ExampleTestData))]
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
        Assert.AreEqual(529, result);
    }

    [TestMethod]
    [DynamicData(nameof(Part2ExampleTestData))]
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
        Assert.AreEqual(20386, result);
    }

    public static IEnumerable<(string input, int expected)> Part1ExampleTestData()
    {
        yield return (
            """
            R8,U5,L5,D3
            U7,R6,D4,L4
            """, 3 + 3);


        yield return (
            """
            R75,D30,R83,U83,L12,D49,R71,U7,L72
            U62,R66,U55,R34,D71,R55,D58,R83
            """, 159);


        yield return (
            """
            R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51
            U98,R91,D20,R16,D67,R40,U7,R15,U6,R7
            """, 135);
    }
    public static IEnumerable<(string input, int expected)> Part2ExampleTestData()
    {
        yield return (
            """
            R8,U5,L5,D3
            U7,R6,D4,L4
            """, 15 + 15);


        yield return (
            """
            R75,D30,R83,U83,L12,D49,R71,U7,L72
            U62,R66,U55,R34,D71,R55,D58,R83
            """, 610);


        yield return (
            """
            R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51
            U98,R91,D20,R16,D67,R40,U7,R15,U6,R7
            """, 410);
    }
}