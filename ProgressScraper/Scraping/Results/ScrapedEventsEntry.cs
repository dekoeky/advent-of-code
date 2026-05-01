namespace AdventOfCode.ProgressScraper.Scraping.Results;

public record ScrapedEventsEntry
{
    public int Year { get; set; }
    public int StarsAchievable { get; set; }
    public int StarsAchieved { get; set; }
    public string Href { get; set; }
}