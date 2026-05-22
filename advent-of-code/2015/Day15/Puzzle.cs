namespace advent_of_code._2015.Day15;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Combinations_AddingUpToTarget()
    {
        // Arrange
        var count = 3;
        var target = 4;

        // Act
        foreach (var item in Combinations.AddingUpToTarget(count, target))
            Console.WriteLine($"{string.Join(" + ", item)} = {target}");
    }

    [TestMethod]
    public void Part1CalculateScore()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var ingredients = Ingredients.Parse(input);
        var result = Calculations.CalculateScore(ingredients, [44, 56], null);

        // Assert
        Assert.AreEqual(62842880L, result);
    }

    [TestMethod]
    public void Part1Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.HighestScoringRecipe(input);

        // Assert
        Assert.AreEqual(62842880, result);
    }


    [TestMethod]
    public void Part1Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.HighestScoringRecipe(input);

        // Assert
        Assert.AreEqual(222870, result);
    }

    [TestMethod]
    public void Part2CalculateScore()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var ingredients = Ingredients.Parse(input);
        var result = Calculations.CalculateScore(ingredients, [40, 60], 500);

        // Assert
        Assert.AreEqual(57600000L, result);
    }

    [TestMethod]
    public void Part2Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var result = Calculations.HighestScoringRecipe(input, 500);

        // Assert
        Assert.AreEqual(57600000L, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var result = Calculations.HighestScoringRecipe(input, 500);

        // Assert
        Assert.AreEqual(117936L, result);
    }
}
