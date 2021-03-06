using NUnit.Framework;
using NUnit.Framework.Internal;
using Wingmann.Algorithms.Search;

namespace Wingmann.Algorithms.Tests.Search;

public static class LinearSearcherTests
{
    [Test]
    public static void FindIndex_ItemPresent_IndexCorrect([Random(1, 1_000, 100)] int n)
    {
        var random = Randomizer.CreateRandomizer();
        var data = Enumerable
            .Range(0, n)
            .Select(x => random.Next(0, 1_000))
            .OrderBy(x => x)
            .ToArray();
        
        var selectedIndex = random.Next(0, n);
        var actual = new LinearSearcher().FindIndex(data, data[selectedIndex]);
        
        Assert.AreEqual(data[selectedIndex], data[actual]);
    }

    [Test]
    public static void FindIndex_ItemMissing_MinusOneReturned(
        [Random(0, 1_000, 10)] int n,
        [Random(-100, 1_100, 10)] int missingItem)
    {
        var random = Randomizer.CreateRandomizer();
        var data = Enumerable
            .Range(0, n)
            .Select(x => random.Next(0, 1_000))
            .Where(x => x != missingItem)
            .OrderBy(x => x)
            .ToArray();

        var actual = new LinearSearcher().FindIndex(data, missingItem);
        
        Assert.AreEqual(-1, actual);
    }

    [Test]
    public static void FindIndex_ArrayEmpty_MinusOneReturned([Random(100)] int itemToSearch)
    {
        var actual = new LinearSearcher().FindIndex(Array.Empty<int>(), itemToSearch);

        Assert.AreEqual(-1, actual);
    }
}
