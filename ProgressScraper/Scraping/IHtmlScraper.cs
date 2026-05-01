namespace AdventOfCode.ProgressScraper.Scrapers;

internal interface IHtmlScraper<TOut>
{
    TOut Scrape(string html);
}
