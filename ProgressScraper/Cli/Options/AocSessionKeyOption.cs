using System.CommandLine;

namespace AdventOfCode.ProgressScraper.Cli.Options;

internal class AocSessionKeyOption() : Option<string>("session", "s");