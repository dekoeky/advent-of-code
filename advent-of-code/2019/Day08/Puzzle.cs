namespace advent_of_code._2019.Day08;

/// <summary>
/// Year 2019 Day 08 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2019/day/8"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example1;

        // Act
        var result = Calculations.Part1(input, w: 3, h: 2);

        // Assert
        Assert.AreEqual(1 * 1, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.Part1(input, w: 25, h: 6);

        // Assert
        Assert.AreEqual(2125, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example2;
        var expected =
            """
             #
            # 
            """;

        // Act
        var result = Calculations.Part2(input, 2, 2);

        // Assert
        Assert.AreEqual(expected, result, NewlineInsensitiveStringComparer.Instance);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;
        var expected =
            """
              ## #   ##### #  # #### 
               # #   #   # #  # #    
               #  # #   #  #### ###  
               #   #   #   #  # #    
            #  #   #  #    #  # #    
             ##    #  #### #  # #     
            """; // JYZHF

        // Act
        var result = Calculations.Part2(input, 25, 6);

        // Assert
        Assert.AreEqual(expected, result, NewlineInsensitiveStringComparer.Instance);
    }
}
