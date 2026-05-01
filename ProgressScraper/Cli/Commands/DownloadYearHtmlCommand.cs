
using System.CommandLine.Completions;

using AdventOfCode.ProgressScraper.Cli.Arguments;

namespace AdventOfCode.ProgressScraper.Cli.Commands;


internal class DownloadYearHtmlCommand : Command
{
    private readonly YearArgument _year = new();

    public DownloadYearHtmlCommand() : base("download-year")
    {
        Add(_year);
        SetAction(Download);
    }

    private async Task<int> Download(ParseResult pr, CancellationToken ct)
    {
        var year = pr.GetValue(_year);
        Console.Write($"Downloading year {year}");
        for (var i = 0; i < 10; i++)
        {
            Console.Write('.');
            await Task.Delay(100, ct);
        }
        Console.WriteLine();
        Console.WriteLine("Done"!);
        return 0;
    }

    public override IEnumerable<CompletionItem> GetCompletions(CompletionContext context)
    {
        var thisYear = DateTime.Now.Year;

        for (var year = 2015; year <= thisYear; year++)
            yield return new CompletionItem(year.ToString());
    }
}