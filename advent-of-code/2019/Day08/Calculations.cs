using System.Text;

namespace advent_of_code._2019.Day08;

internal static class Calculations
{
    public static int Part1(ReadOnlySpan<char> input, int w, int h)
    {
        var len = input.Length;
        var layerSize = w * h;

        if (len % layerSize != 0) throw new InvalidOperationException("Assumption 'No Partial Layers' was invalid");
        var layers = len / layerSize;
        var layerData = new (int Zeros, int Ones, int Twos)[layers];

        for (var l = 0; l < layers; l++)
            foreach (var c in input.Slice(l * layerSize, layerSize))
                switch (c)
                {
                    case '0': layerData[l].Zeros++; break;
                    case '1': layerData[l].Ones++; break;
                    case '2': layerData[l].Twos++; break;
                    default: break;
                }

        var least = int.MaxValue;
        var leastIndex = -1;

        for (var l = 0; l < layers; l++)
        {
            var data = layerData[l];

            if (data.Zeros >= least)
                continue;

            least = data.Zeros;
            leastIndex = l;
        }

        return layerData[leastIndex].Ones * layerData[leastIndex].Twos;
    }

    public static string Part2(ReadOnlySpan<char> input, int w, int h)
    {
        var len = input.Length;
        var layerSize = w * h;

        if (len % layerSize != 0) throw new InvalidOperationException("Assumption 'No Partial Layers' was invalid");
        var layers = len / layerSize;
        Span<char> resultLayer = stackalloc char[layerSize];
        resultLayer.Fill('2'); // Transparent

        for (var l = 0; l < layers; l++)
        {
            var layer = input.Slice(l * layerSize, layerSize);

            for (var i = 0; i < layer.Length; i++)
            {
                // If this pixel was already not transparent, don't process this pixel anymore
                if (resultLayer[i] != '2') continue;

                resultLayer[i] = layer[i];
            }
        }

        return Plot(resultLayer, w, h);
    }

    private static string Plot(ReadOnlySpan<char> layer, int width, int height)
    {
        var sb = new StringBuilder(layer.Length + Environment.NewLine.Length * height);

        var i = 0;
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var px = layer[i] switch
                {
                    // Black or Transparent
                    '0' or '2' => ' ',
                    // White
                    '1' => '#',
                    _ => throw new InvalidOperationException("Invalid Pixel Color"),
                };

                sb.Append(px);
                i++;
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
}