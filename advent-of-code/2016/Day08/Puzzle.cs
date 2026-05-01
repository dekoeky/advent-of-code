namespace AdventOfCode._2016.Day08;

/// <summary>
/// Year 2016 Day 08 solution.
/// </summary>
/// <seealso href="https://adventofcode.com/2016/day/8"/>
[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var screen = Screen.GetResult(input);
        var result = screen.Count();

        // Assert
        Assert.AreEqual(110, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var screen = Screen.GetResult(input);
        var result = Screen.ToString(screen);

        // Assert
        Assert.AreEqual(
            """
            ####   ## #  # ###  #  #  ##  ###  #    #   #  ## 
               #    # #  # #  # # #  #  # #  # #    #   #   # 
              #     # #### #  # ##   #    #  # #     # #    # 
             #      # #  # ###  # #  #    ###  #      #     # 
            #    #  # #  # # #  # #  #  # #    #      #  #  # 
            ####  ##  #  # #  # #  #  ##  #    ####   #   ##  
            """
            , result);
    }
}