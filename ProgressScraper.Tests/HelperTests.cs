using System.Diagnostics;

using AdventOfCode.ProgressScraper.Clients;

using Microsoft.Extensions.Configuration;

namespace AdventOfCode.ProgressScraper;

[Ignore("Run this test manually when you need it")]
[TestClass]
public class HelperTests
{
    private const string SessionKey = "Aoc:session";
    private static readonly IConfiguration Config = new ConfigurationBuilder()
        .AddUserSecrets<HelperTests>()
        .Build();

    private static string Session => Config[SessionKey]
        ?? throw new InvalidOperationException($"{SessionKey} not provided");

    private static AdventOfCodeClient GetClient() => new(Session);

    [TestMethod]
    public async Task AllHtml()
    {
        // Arrange
        var outputDir = "output/html";
        var client = GetClient();

        // Act
        var htmls = await client.AllHtml(CancellationToken.None);

        outputDir = Path.GetFullPath(outputDir);
        Directory.CreateDirectory(outputDir);
        foreach (var (key, contents) in htmls)
        {
            var fileName = $"{key}.html";
            var filePath = Path.Join(outputDir, fileName);
            Debug.WriteLine($"Storing {fileName}: {filePath}");
            await File.WriteAllTextAsync(filePath, contents, CancellationToken.None);
        }
    }
}
