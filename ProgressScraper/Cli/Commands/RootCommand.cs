
namespace AdventOfCode.ProgressScraper.Cli.Commands;

internal class RootCommand : System.CommandLine.RootCommand
{

    // Temp for global usings
    DemoArgument a;
    AocSessionKeyOption b;

    public RootCommand() : base("Progress Scraper")
    {
        Add(new DownloadYearHtmlCommand());
    }
}
