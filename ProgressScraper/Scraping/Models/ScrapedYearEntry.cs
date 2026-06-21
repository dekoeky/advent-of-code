namespace AdventOfCode.ProgressScraper.Scraping.Results;

public record ScrapedYearEntry
{
    public int Day { get; set; }
    public bool CompleteMark { get; set; }
    public bool VeryCompleteMark { get; set; }
    public string Href { get; set; }
}
