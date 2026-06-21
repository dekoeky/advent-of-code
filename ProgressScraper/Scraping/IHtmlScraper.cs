namespace AdventOfCode.ProgressScraper.Scraping;

internal interface IHtmlScraper<TOut>
{
    TOut Scrape(string html);
}
