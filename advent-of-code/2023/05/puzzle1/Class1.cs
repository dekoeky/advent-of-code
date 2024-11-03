namespace advent_of_code._2023._05.puzzle1;

[TestClass]
public class Class1
{
    [DataTestMethod]
    [DataRow(35)]
    public void Example(NumberType expected)
    {
        var inputFile = "2024/05/puzzle1/input/example.txt";
        var almanac = Almanac.FromFile(inputFile);

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

        Assert.AreEqual(expected, lowest.Location);
        Console.WriteLine($"Seed: {lowest.Seed}, Location: {lowest.Location}");
    }

    [TestMethod]
    public void foo()
    {
        var inputFile = "2024/05/puzzle1/input/input.txt";
        var almanac = Almanac.FromFile(inputFile);

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

        Console.WriteLine($"Seed: {lowest.Seed}, Location: {lowest.Location}");
    }
}