using System.Text.RegularExpressions;

using AdventOfCode.ProgressScraper.Scrapers;
using AdventOfCode.ProgressScraper.Scraping.Results;

namespace AdventOfCode.ProgressScraper.Scraping.Scrapers;

internal partial record EventsHtmlScraper : IHtmlScraper<ScrapedEvents>
{
    [GeneratedRegex(@"<div\s+class=""eventlist-event"">\s*<a\s+href=""(?<href>[^""]*)"">\[(?<year>\d{4})\]</a>\s*<span\s+class=""star-count"">\s*(?<achieved>\d+)\*\s*</span>\s*<span\s+class=""quiet"">\s*/\s*(?<achievable>\d+)\*\s*</span>\s*</div>")]
    internal static partial Regex Regex { get; }

    [GeneratedRegex(@"<p>\s*Total\s+stars:\s*<span\s+class=""star-count"">\s*(?<stars>\d+)\*\s*</span>\s*</article>")]
    internal static partial Regex R2 { get; }

    public ScrapedEvents Scrape(string html)
    {

        var result = new ScrapedEvents();

        //foreach (Match match in Regex.Matches(html))
        //{
        //    Debug.WriteLine(match.Value);
        //    foreach (Group group in match.Groups.Values)
        //        Debug.WriteLine($"{group.Name} : {group.Value}");

        //    Debug.WriteLine();
        //}


        if (R2.Match(html) is { Success: true } m2)
            result.TotalStars = int.Parse(m2.Groups["stars"].ValueSpan);

        foreach (Match match in Regex.Matches(html))
            result.Entries.Add(new ScrapedEventsEntry
            {
                Year = int.Parse(match.Groups["year"].ValueSpan),
                Href = match.Groups["href"].Value,
                StarsAchieved = int.Parse(match.Groups["achieved"].ValueSpan),
                StarsAchievable = int.Parse(match.Groups["achievable"].ValueSpan),
            });



        return result;
    }
}
