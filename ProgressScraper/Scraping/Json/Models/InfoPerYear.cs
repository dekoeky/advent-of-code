namespace AdventOfCode.ProgressScraper.Scraping.Json.Models;

internal record InfoPerYear
{
    public int Year { get; set; }
    public int Days { get; set; }
    public int StarsAchieved { get; set; }
    public int StarsAchievable { get; set; }
    public string HRefRelative { get; set; }
    public string HRefAbsolute { get; set; }
}