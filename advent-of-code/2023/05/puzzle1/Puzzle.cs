namespace advent_of_code._2023._05.puzzle1;

[TestClass]
public class Puzzle
{
    [TestMethod]
    public void Example()
    {
        // Arrange
        var input = Inputs.Example;

        // Act
        var almanac = Almanac.Parse(input);

        //What is the lowest location number that corresponds to any of the initial seed numbers?

        var lowest = almanac.Seeds
            .Select(s =>
            {
                var mapper = almanac["seed", "location"];

                return new
                {
                    Seed = s,
                    Location = mapper.Lookup(s),
                };
            })
            .MinBy(mb => mb.Location);

        // Assert
        Assert.IsNotNull(lowest);
        Assert.AreEqual(35uL, lowest.Location);
        Console.WriteLine($"Seed: {lowest.Seed}, Location: {lowest.Location}");
    }

    [TestMethod]
    public void Foo()
    {
        // Arrange
        var input = Inputs.Puzzle;

        // Act
        var almanac = Almanac.Parse(input);

        //What is the lowest location number that corresponds to any of the initial seed numbers?

        var lowest = almanac.Seeds
            .Select(s =>
            {
                var mapper = almanac["seed", "location"];

                return new
                {
                    Seed = s,
                    Location = mapper.Lookup(s),
                };
            })
            .MinBy(mb => mb.Location);

        // Assert
        Assert.IsNotNull(lowest);
        Console.WriteLine($"Seed: {lowest.Seed}, Location: {lowest.Location}");
    }
}