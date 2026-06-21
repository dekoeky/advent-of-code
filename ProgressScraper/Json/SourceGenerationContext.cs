using System.Text.Json.Serialization;

using AdventOfCode.ProgressScraper.Conversion.Models;
using AdventOfCode.ProgressScraper.Scraping.Results;

namespace AdventOfCode.ProgressScraper.Json;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(InfoTotal))]
[JsonSerializable(typeof(InfoPerYear))]
[JsonSerializable(typeof(InfoPerDay))]
[JsonSerializable(typeof(ScrapedEvents))]
[JsonSerializable(typeof(ScrapedEventsEntry))]
[JsonSerializable(typeof(ScrapedYear))]
[JsonSerializable(typeof(ScrapedYearEntry))]
internal partial class SourceGenerationContext : JsonSerializerContext
{

}