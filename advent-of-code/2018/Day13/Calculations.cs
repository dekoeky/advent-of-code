namespace advent_of_code._2018.Day13;

internal static class Calculations
{
    public static string Part1(ReadOnlySpan<char> input)
        => NewMethod(input, true);

    public static string Part2(ReadOnlySpan<char> input)
        => NewMethod(input, false);

    private static string NewMethod(ReadOnlySpan<char> input, bool returnOnCollision)
    {
        var grid = Parse(input);
        var carts = ExtractCarts(grid);
        var comparer = new CartComparer();

        while (true)
        {
            carts.Sort(comparer);

            // Move each cart, topleft to bottom right order
            foreach (var cart in carts.ToList()) // ToList to allow modification of the list
            {
                // This cart might have been removed in a collission
                if (!carts.Contains(cart)) continue;

                var tile = grid[cart.Position.Y, cart.Position.X];

                switch (tile)
                {
                    case '-':
                    case '|':
                        Move(cart);
                        break;

                    case '\\':
                        Rotate(cart, '\\');
                        Move(cart);
                        break;

                    case '/':
                        Rotate(cart, '/');
                        Move(cart);
                        break;

                    case '+':

                        // Each time a cart has the option to turn (by arriving at any intersection),
                        // it turns left the first time,
                        // goes straight the second time,
                        // turns right the third time,
                        // and then repeats those directions starting again with left the fourth time,
                        // straight the fifth time, and so on.
                        // This process is independent of the particular intersection at which
                        // the cart has arrived - that is, the cart has no per-intersection memory.

                        // 0 -> left
                        // 1 -> straight
                        // 2 -> right
                        switch (cart.CrossRoadCounter++ % 3)
                        {
                            case 0:
                                TurnLeft(cart);
                                Move(cart);
                                break;
                            case 1:
                                // No Turn
                                Move(cart);
                                break;
                            case 2:
                                TurnRight(cart);
                                Move(cart);
                                break;
                        }
                        break;
                }

                if (!Collision(carts, cart.Position))
                    continue;

                if (returnOnCollision)
                    return $"{cart.Position.X},{cart.Position.Y}";
                else
                    carts.RemoveAll(c => c.Position == cart.Position);
            }

            if (carts.Count > 1) continue;
            if (carts.Count == 0) throw new InvalidOperationException("Cart count became 0");

            var finalCartPosition = carts.Single().Position;
            return $"{finalCartPosition.X},{finalCartPosition.Y}";
        }
        throw new InvalidOperationException();
    }

    private static bool Collision(IReadOnlyCollection<Cart> carts, Point position)
        => carts.Count(c => c.Position == position) >= 2;

    private static void Rotate(Cart cart, char tile)
    {
        switch (tile)
        {
            case '\\':
                switch (cart.Direction)
                {
                    case 'v':
                        cart.Direction = '>';
                        break;
                    case '^':
                        cart.Direction = '<';
                        break;
                    case '<':
                        cart.Direction = '^';
                        break;
                    case '>':
                        cart.Direction = 'v';
                        break;
                }
                break;

            case '/':
                switch (cart.Direction)
                {
                    case 'v':
                        cart.Direction = '<';
                        break;
                    case '^':
                        cart.Direction = '>';
                        break;
                    case '<':
                        cart.Direction = 'v';
                        break;
                    case '>':
                        cart.Direction = '^';
                        break;
                }
                break;

            default:
                break;
        }
    }

    private static char TurnLeft(char direction) => direction switch
    {
        '>' => '^',
        '^' => '<',
        '<' => 'v',
        'v' => '>',
        _ => throw new NotImplementedException(),
    };

    private static char TurnRight(char direction) => direction switch
    {
        '>' => 'v',
        'v' => '<',
        '<' => '^',
        '^' => '>',
        _ => throw new NotImplementedException(),
    };

    private static void TurnRight(Cart cart) => cart.Direction = TurnRight(cart.Direction);
    private static void TurnLeft(Cart cart) => cart.Direction = TurnLeft(cart.Direction);

    private static void Move(Cart cart)
    {
        switch (cart.Direction)
        {
            case '>':
                cart.Position.X++;
                break;
            case 'v':
                cart.Position.Y++;
                break;
            case '<':
                cart.Position.X--;
                break;
            case '^':
                cart.Position.Y--;
                break;
        }
    }

    private static List<Cart> ExtractCarts(char[,] map)
    {
        List<Cart> carts = [];

        var rows = map.GetLength(0);
        var cols = map.GetLength(1);

        for (var r = 0; r < rows; r++)
            for (var c = 0; c < cols; c++)
            {
                var tile = map[r, c];

                switch (tile)
                {
                    case '>':
                    case '<':
                        carts.Add(new() { Direction = tile, Position = new Point(c, r) });
                        map[r, c] = '-';
                        break;
                    case 'v':
                    case '^':
                        carts.Add(new() { Direction = tile, Position = new Point(c, r) });
                        map[r, c] = '|';
                        break;
                }
            }

        return carts;
    }

    private static char[,] Parse(ReadOnlySpan<char> input)
    {
        var rows = input.Count('\n') + 1;
        var cols = input.IndexOfAny('\n', '\r');

        var data = new char[rows, cols];

        var r = 0;
        var c = 0;

        foreach (var line in input.EnumerateLines())
        {
            for (c = 0; c < cols; c++)
            {
                data[r, c] = line[c];
            }
            r++;
        }

        return data;
    }
}

