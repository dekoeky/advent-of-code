namespace AdventOfCode.ProgressScraper.Scraping.Results;

/// <summary>
/// Raw information scraped from a given years html page.
/// </summary>
public record ScrapedYear
{
    public int Year { get; set; }
    public ICollection<ScrapedYearEntry> Entries { get; init; } = [];
}
