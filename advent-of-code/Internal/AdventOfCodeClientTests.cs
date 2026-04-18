using Microsoft.Extensions.Configuration;

namespace advent_of_code.Internal;

/// <summary>
/// <see cref="AdventOfCodeClient"/> tests.
/// </summary>
[TestClass]
public class AdventOfCodeClientTests
{
    private static readonly IConfiguration Config = new ConfigurationBuilder()
        .AddUserSecrets<AdventOfCodeClientTests>()
        .Build();

    internal static AdventOfCodeClient GetClient()
        => new(Config["Aoc:session"]
            ?? throw new ArgumentNullException("Aoc:session"));

    [TestMethod]
    [DataRow(2015, 18)]
    public async Task PuzzleInput(int year, int day)
    {
        // Arrange
        var client = GetClient();

        // Act
        var puzzleInput = await client.PuzzleInput(year, day);

        // Assert
        Assert.IsNotEmpty(puzzleInput);
        Console.WriteLine(puzzleInput);
    }
}