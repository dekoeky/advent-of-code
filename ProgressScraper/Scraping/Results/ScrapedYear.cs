namespace AdventOfCode.ProgressScraper.Scraping.Results;

public record ScrapedYear
{
    public int Year { get; set; }
    public ICollection<ScrapedYearEntry> Entries { get; init; } = [];
}
