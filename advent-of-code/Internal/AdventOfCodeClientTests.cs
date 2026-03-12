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

    private readonly AdventOfCodeClient _client = new(Config["Aoc:session"]);

    [TestMethod]
    [DataRow(2015, 18)]
    public async Task PuzzleInput(int year, int day)
    {
        // Act
        var puzzleInput = await _client.PuzzleInput(year, day);

        // Assert
        Assert.IsNotEmpty(puzzleInput);
        Console.WriteLine(puzzleInput);
    }
}