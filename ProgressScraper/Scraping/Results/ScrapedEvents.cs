namespace AdventOfCode.ProgressScraper.Scraping.Results;

public record ScrapedEvents
{
    public int? TotalStars { get; set; }
    public ICollection<ScrapedEventsEntry> Entries { get; init; } = [];
}
