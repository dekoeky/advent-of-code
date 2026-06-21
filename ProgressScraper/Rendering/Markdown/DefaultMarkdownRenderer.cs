using AdventOfCode.ProgressScraper.Conversion.Models;

namespace AdventOfCode.ProgressScraper.Rendering.Markdown;

internal class DefaultMarkdownRenderer(Stream stream) : IDisposable
{
    private readonly StreamWriter _streamWriter = new(stream);

    public void Dispose()
    {
        _streamWriter.Dispose();
    }

    public void Render(InfoTotal info)
    {

    }
}
