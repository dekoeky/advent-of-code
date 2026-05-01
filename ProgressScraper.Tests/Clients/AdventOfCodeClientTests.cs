using System.Diagnostics;

using Microsoft.Extensions.Configuration;

namespace AdventOfCode.ProgressScraper.Clients;

/// <summary>
/// <see cref="AdventOfCodeClient"/> tests.
/// </summary>
[TestClass]
public class AdventOfCodeClientTests
{
    private const string SessionKey = "Aoc:session";
    private static readonly IConfiguration Config = new ConfigurationBuilder()
        .AddUserSecrets<AdventOfCodeClientTests>()
        .Build();

    private static string Session => Config[SessionKey]
        ?? throw new InvalidOperationException($"{SessionKey} not provided");

    private static AdventOfCodeClient GetClient() => new(Session);

    [TestMethod]
    public async Task EventsHtml()
    {
        // Arrange
        var client = GetClient();

        // Act
        var html = await client.EventsHtml(CancellationToken.None);

        // Assert
        Debug.WriteLine(html);
        Assert.IsNotEmpty(html);
    }

    [TestMethod]
    [DataRow(2015)]
    public async Task YearHtml(int year, CancellationToken ct = default)
    {
        // Arrange
        var client = GetClient();

        // Act
        var html = await client.YearHtml(year, ct);

        // Assert
        Debug.WriteLine(html);
        Assert.IsNotEmpty(html);
    }

    [TestMethod]
    [DataRow(2015, 18)]
    public async Task PuzzleHtml(int year, int day, CancellationToken ct = default)
    {
        // Arrange
        var client = GetClient();

        // Act
        var html = await client.PuzzleHtml(year, day, ct);

        // Assert
        Debug.WriteLine(html);
        Assert.IsNotEmpty(html);
    }

    [TestMethod]
    [DataRow(2015, 18)]
    public async Task PuzzleInput(int year, int day, CancellationToken ct = default)
    {
        // Arrange
        var client = GetClient();

        // Act
        var puzzleInput = await client.PuzzleInput(year, day, ct);

        // Assert
        Debug.WriteLine(puzzleInput);
        Assert.IsNotEmpty(puzzleInput);
    }

    [TestMethod]
    public async Task AllHtml()
    {
        // Arrange
        // +1 to include events.
        // Current year not included, because it might not be available yet, dependon on which month we are
        var expected = DateTime.Now.Year - 2015 + 1;
        var client = GetClient();

        // Act
        var htmls = await client.AllHtml(CancellationToken.None);

        // Assert
        foreach (var (key, content) in htmls)
            Debug.WriteLine($"{key}.html:\n{content}\n\n");
        Assert.IsGreaterThanOrEqualTo(expected, htmls.Count);
        Assert.ValuesNotNull(htmls);
    }
}
