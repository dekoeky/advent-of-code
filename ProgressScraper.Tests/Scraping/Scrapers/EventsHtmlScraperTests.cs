using System.Diagnostics;
using System.Text.Json;

using AdventOfCode.ProgressScraper.Json;

namespace AdventOfCode.ProgressScraper.Scraping.Scrapers;

/// <summary>
/// <see cref="EventsHtmlScraper"/> tests.
/// </summary>
[TestClass]
public class EventsHtmlScraperTests
{
    [TestMethod]
    [DataRow(@"output\html\events.html")]
    public async Task Scrape(string htmlFilePath)
    {
        // Arrange
        var html = File.ReadAllText(htmlFilePath);
        var scraper = new EventsHtmlScraper();

        // Act
        var result = scraper.Scrape(html);

        // Assert
        Assert.IsNotNull(result);
        var json = JsonSerializer.Serialize(result, SourceGenerationContext.Default.ScrapedEvents);
        Debug.WriteLine(json);
    }
}
