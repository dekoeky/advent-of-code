using System.Diagnostics;
using System.Net;

namespace AdventOfCode.ProgressScraper.Clients;

internal class AdventOfCodeClient : IDisposable
{
    private const string Domain = "adventofcode.com";
    private const string Url = "https://adventofcode.com";
    private static readonly Uri Uri = new(Url);

    private const int FirstYear = 2015;

    private readonly HttpClientHandler _handler;
    private readonly HttpClient _client;

    // TODO: Consider injecting ILogger

    public AdventOfCodeClient(string session)
    {
        _handler = new HttpClientHandler
        {
            CookieContainer = new CookieContainer(),
        };
        _handler.CookieContainer.Add(Uri, new Cookie("session", session, "/", Domain));

        _client = new HttpClient(_handler)
        {
            BaseAddress = Uri,
        };

        //_client.DefaultRequestHeaders.UserAgent.ParseAdd("github-dekoeky");
    }

    public void Dispose()
    {
        _client.Dispose();
        _handler.Dispose();
    }

    public async Task<Dictionary<string, string>> AllHtml(CancellationToken ct = default)
    {
        var current = DateTime.Now.Year;
        var years = current - FirstYear + 1;

        Dictionary<string, string> html = new(years + 1);

        html["events"] = await EventsHtml(ct);

        // TODO: Consider parallelizing requests
        for (var year = FirstYear; year < current; year++)
            try
            {
                html[year.ToString()] = await YearHtml(year, ct);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                Debug.WriteLine($"HTML for year {year} not found.");
            }

        return html;
    }

    public Task<string> EventsHtml(CancellationToken ct = default)
        => _client.GetStringAsync($"events", ct);

    public Task<string> YearHtml(int year, CancellationToken ct = default)
        => _client.GetStringAsync($"{year}", ct);

    public Task<string> PuzzleHtml(int year, int day, CancellationToken ct = default)
        => _client.GetStringAsync($"{year}/day/{day}", ct);

    public Task<string> PuzzleInput(int year, int day, CancellationToken ct = default)
        => _client.GetStringAsync($"{year}/day/{day}/input", ct);
}

