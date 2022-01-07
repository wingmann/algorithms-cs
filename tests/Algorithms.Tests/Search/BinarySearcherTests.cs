using Algorithms.Search;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Algorithms.Tests.Search;

public static class BinarySearcherTests
{
    [Test]
    public static void FindIndex_ItemPresent_IndexCorrect([Random(1, 1_000, 100)] int n)
    {
        // Arrange.
        var random = Randomizer.CreateRandomizer();
        var arrayToSearch = Enumerable.Range(0, n).Select(x => random.Next(0, 1000)).OrderBy(x => x).ToArray();
        var selectedIndex = random.Next(0, n);

        // Act.
        var actualIndex = BinarySearcher.FindIndex(arrayToSearch, arrayToSearch[selectedIndex]);

        // Assert.
        Assert.AreEqual(arrayToSearch[selectedIndex], arrayToSearch[actualIndex]);
    }

    [Test]
    public static void FindIndex_ItemMissing_MinusOneReturned(
        [Random(0, 1_000, 10)] int n,
        [Random(-100, 1_100, 10)] int missingItem)
    {
        // Arrange.
        var random = Randomizer.CreateRandomizer();
        var arrayToSearch = Enumerable.Range(0, n)
            .Select(x => random.Next(0, 1_000))
            .Where(x => x != missingItem)
            .OrderBy(x => x).ToArray();

        // Act.
        var actualIndex = BinarySearcher.FindIndex<int>(arrayToSearch, missingItem);

        // Assert.
        Assert.AreEqual(-1, actualIndex);
    }

    [Test]
    public static void FindIndex_ArrayEmpty_MinusOneReturned([Random(100)] int itemToSearch)
    {
        // Arrange.
        var arrayToSearch = Array.Empty<int>();

        // Act.
        var actualIndex = BinarySearcher.FindIndex(arrayToSearch, itemToSearch);

        // Assert.
        Assert.AreEqual(-1, actualIndex);
    }
}
