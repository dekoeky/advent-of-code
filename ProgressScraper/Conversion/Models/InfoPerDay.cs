namespace AdventOfCode.ProgressScraper.Conversion.Models;

internal record InfoPerDay
{
    public int Year { get; set; }
    public int Day { get; set; }
    public int StarsAchieved { get; set; }
    public int StarsAchievable { get; set; }
    public string HRefRelative { get; set; }
    public string HRefAbsolute { get; set; }
}
