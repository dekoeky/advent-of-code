using System.Net;

namespace advent_of_code.Internal;

internal class AdventOfCodeClient : IDisposable
{
    private const string Domain = "adventofcode.com";
    private const string Url = "https://adventofcode.com";
    private static readonly Uri Uri = new(Url);

    private readonly HttpClientHandler _handler;
    private readonly HttpClient _client;

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

        //client.DefaultRequestHeaders.UserAgent.ParseAdd("github-dekoeky");
    }

    public void Dispose()
    {
        _client.Dispose();
        _handler.Dispose();
    }

    public Task<string> PuzzleInput(int year, int day) => _client.GetStringAsync($"{year}/day/{day}/input");
}

