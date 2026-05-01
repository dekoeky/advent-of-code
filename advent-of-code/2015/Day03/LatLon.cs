namespace AdventOfCode._2015.Day03;

internal record struct LatLon(int Lat, int Lon)
{
    public void Move(char direction)
    {
        switch (direction)
        {
            case '^': Lat++; break;
            case 'v': Lat--; break;
            case '>': Lon++; break;
            case '<': Lon--; break;
            default: throw new ArgumentException();
        }
    }
}