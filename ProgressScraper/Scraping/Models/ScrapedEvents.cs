namespace AdventOfCode.ProgressScraper.Scraping.Results;

/// <summary>
/// Raw information scraped from the events html page.
/// </summary>
public record ScrapedEvents
{
    /// <summary>
    /// The displayed "Total Stars xxx*" value.
    /// </summary>
    public int? TotalStars { get; set; }
    public ICollection<ScrapedEventsEntry> Entries { get; init; } = [];
}
