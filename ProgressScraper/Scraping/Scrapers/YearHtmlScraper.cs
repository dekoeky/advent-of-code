using System.Text.RegularExpressions;

using AdventOfCode.ProgressScraper.Scrapers;
using AdventOfCode.ProgressScraper.Scraping.Results;

namespace AdventOfCode.ProgressScraper.Scraping.Scrapers;

internal partial record YearHtmlScraper : IHtmlScraper<ScrapedYear>
{
    [GeneratedRegex(@"<a[^>]*href=""(?<href>[^""]+)""[^>]*>.*?<span\s+class=""calendar-day"">\s*(?<day>\d+)\s*</span>(?<complete>\s*<span\s+class=""calendar-mark-complete"">\*</span>)?(?<verycomplete>\s*<span\s+class=""calendar-mark-verycomplete"">\*</span>)?.*?</a>")]
    internal static partial Regex Regex { get; }

    //[GeneratedRegex("@\"<title>\\s*Advent of Code (?<year>\\d{4})\\s*</title>\"")]
    [GeneratedRegex(@"<title>\s*Advent\s+of\s+Code\s+(?<year>\d{4})\s*</title>")]
    internal static partial Regex TitleRegex { get; }

    public ScrapedYear Scrape(string html)
    {
        var result = new ScrapedYear();

        //foreach (Match match in Regex.Matches(html))
        //{
        //    Debug.WriteLine(match.Value);
        //    foreach (Group group in match.Groups.Values)
        //        Debug.WriteLine($"{group.Name} : {group.Value}");

        //    Debug.WriteLine();
        //}

        // Extract year from title
        if (TitleRegex.Match(html) is not { Success: true } matchTitle)
            throw new InvalidOperationException("Could not extract year from title");

        result.Year = int.Parse(matchTitle.Groups["year"].ValueSpan);


        foreach (Match match in Regex.Matches(html))
            result.Entries.Add(new ScrapedYearEntry
            {
                Day = int.Parse(match.Groups["day"].ValueSpan),
                Href = match.Groups["href"].Value,
                CompleteMark = match.Groups["complete"].Success,
                VeryCompleteMark = match.Groups["verycomplete"].Success,
            });

        return result;
    }
}
