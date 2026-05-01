using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode._2016.Day05;

internal static class Calculations
{
    // TODO: Major Performance increase to be found here

    public static string CalculatePassword1(string doorId)
    {
        int index = 0;
        var n = 0;
        var password = new char[8];
        Array.Fill(password, '_');

        while (n < 8)
        {
            var data = $"{doorId}{index++}";
            var bytes = Encoding.ASCII.GetBytes(data);
            var hash = MD5.HashData(bytes);

            // Check if starts with 5 zero characters, before converting to string
            if (hash[0] != 0 || hash[1] != 0 || (hash[2] & 0xF0) != 0) continue;

            var md5Hex = Convert.ToHexStringLower(hash);

            // Fill in additional password character
            password[n++] = md5Hex[5];
        }

        return new string(password);
    }

    public static string CalculatePassword2(string doorId)
    {
        int index = 0;
        var password = new char[8];
        Array.Fill(password, '_');

        while (true)
        {
            var data = $"{doorId}{index++}";
            var bytes = Encoding.ASCII.GetBytes(data);
            var hash = MD5.HashData(bytes);

            // Check if starts with 5 zero characters, before converting to string
            if (hash[0] != 0 || hash[1] != 0 || (hash[2] & 0xF0) != 0) continue;

            var md5Hex = Convert.ToHexStringLower(hash);

            // the sixth character represents the position (0-7)
            var position = md5Hex[5] - '0';
            if (position > 7) continue;

            // Do not overwrite already filled in digits
            if (password[position] != '_') continue;

            var value = md5Hex[6];

            // Fill in additional password character
            password[position] = value;

            if (password.Contains('_')) continue;

            return new string(password);
        }

        throw new InvalidOperationException();
    }
}