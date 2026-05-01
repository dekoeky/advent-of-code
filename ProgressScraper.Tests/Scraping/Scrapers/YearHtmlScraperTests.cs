using System.Diagnostics;

namespace AdventOfCode.ProgressScraper.Scraping.Scrapers;

/// <summary>
/// <see cref="YearHtmlScraper"/> tests.
/// </summary>
[TestClass]
public class YearHtmlScraperTests
{
    [TestMethod]
    [DataRow(@"output\html\2020.html")]
    public async Task Scrape(string htmlFilePath)
    {
        // Arrange
        var html = File.ReadAllText(htmlFilePath);
        var scraper = new YearHtmlScraper();

        // Act
        var result = scraper.Scrape(html);

        // Assert
        Debug.WriteLine(result);
    }
}