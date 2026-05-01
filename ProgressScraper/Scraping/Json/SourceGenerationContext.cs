using System.Text.Json.Serialization;

using AdventOfCode.ProgressScraper.Scraping.Json.Models;

namespace AdventOfCode.ProgressScraper.Scraping.Results;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(Merged))]
internal partial class SourceGenerationContext : JsonSerializerContext
{

}