using advent_of_code.Helpers;
using System.Diagnostics;

namespace advent_of_code._2015.Day09;

internal static class Calculations
{
    public static int ShortestRoute(string input) => EnumerateRoutes(input).Min();
    public static int LongestRoute(string input) => EnumerateRoutes(input).Max();

    private static IEnumerable<int> EnumerateRoutes(string input)
    {
        var routes = SplitOn.NewLines(input).Select(Route.Parse).ToArray();
        Debug.WriteLine("Routes:"); foreach (var route in routes) Debug.WriteLine($"  {route}"); Debug.WriteLine("");

        var from = routes.Select(r => r.From);
        var to = routes.Select(r => r.To);
        var locations = from.Concat(to).Distinct().Order().ToArray();
        Debug.WriteLine("Locations:"); foreach (var location in locations) Debug.WriteLine($"  {location}"); Debug.WriteLine("");

        var x = EnumerateRoutes(locations, routes);
        return x;
    }

    private static IEnumerable<int> EnumerateRoutes(string[] locations, Route[] routes)
    {
        foreach (var permutation in locations.AllPermutations())
        {
            if (TryFindRouteLength(routes, permutation, out var distance))
            {
                Debug.WriteLine($"{string.Join(" -> ", permutation)} = {distance}");
                yield return distance;
            }
            else
            {
                Debug.WriteLine($"{string.Join(" -> ", permutation)} = no route");
            }
        }
    }

    private static bool TryFindRouteLength(Route[] routes, IReadOnlyList<string> iterary, out int distance)
    {
        distance = 0;

        string from;
        string to;

        for (int i = 0; i < iterary.Count - 1; i++)
        {
            from = iterary[i];
            to = iterary[i + 1];

            // If we cant find a distance between this location and the next, we return early
            if (routes.SingleOrDefault(MatchingRoute) is not { } route)
                return false;

            // We found a route from this location to the next
            distance += route.Distance;
        }


        return true;

        // A route matches in both directions
        // We assume only one distance exists between two locations
        bool MatchingRoute(Route r) => (r.From == from && r.To == to) || (r.From == to && r.To == from);
    }
}
