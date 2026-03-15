namespace advent_of_code._2015.Day19;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Part1Example()
    {
        //Arrange
        var input = PuzzleInput.Parse(Inputs.Part1Example);

        //Act
        var result = Calculations.DistinctMutationsCount(input);

        //Assert
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void Part1Puzzle()
    {
        //Arrange
        var input = PuzzleInput.Parse(Inputs.Puzzle);

        //Act
        var result = Calculations.DistinctMutationsCount(input);

        //Assert
        Assert.AreEqual(535, result);
    }

    [TestMethod]
    public void Part2Assumptions()
    {
        var input = PuzzleInput.Parse(Inputs.Puzzle);

        CollectionAssert.TrueForEach(input.Replacements, r => r.Delta >= 0, "Our assumption that replacements never create a shorter result was false");
    }

    [TestMethod]
    [DataRow("HOH", 3)]
    [DataRow("HOHOHO", 6)]
    public void Part2Examples(string target, int expected)
    {
        //Arrange
        var input = PuzzleInput.Parse(Inputs.Part2Example);
        var start = "e";

        //Act
        var result = Calculations.MinStepsToReachTarget(input.Replacements, start, target);

        //Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void Part2Puzzle()
    {
        //Arrange
        var input = PuzzleInput.Parse(Inputs.Puzzle);
        var start = "e";

        //Act
        var result = Calculations.MinStepsToReachTarget(input.Replacements, start, input.Input);

        //Assert
        Assert.AreEqual(212, result);
    }
}