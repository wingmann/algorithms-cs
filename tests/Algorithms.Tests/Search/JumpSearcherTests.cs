using FluentAssertions;
using NUnit.Framework;
using Wingmann.Algorithms.Search;

namespace Wingmann.Algorithms.Tests.Search;

public static class JumpSearcherTests
{
    [Test]
    public static void FindIndex_ItemPresent_ItemCorrect([Random(1, 1_000, 100)] int n)
    {
        var data = Enumerable
            .Range(0, n)
            .Select(_ => TestContext.CurrentContext.Random.Next(1_000_000))
            .OrderBy(x => x)
            .ToArray();
        
        var expected = TestContext.CurrentContext.Random.Next(data.Length);
        var actual = new JumpSearcher().FindIndex(data, data[expected]);
        
        data[actual].Should().Be(data[expected]);
    }

    [Test]
    public static void FindIndex_ItemMissing_MinusOneReturned(
        [Random(1, 1_000, 10)] int n,
        [Random(-100, 1_100, 10)] int missingItem)
    {
        var data = Enumerable
            .Range(0, n)
            .Select(_ => TestContext.CurrentContext.Random.Next(1_000_000))
            .Where(x => x != missingItem)
            .OrderBy(x => x)
            .ToArray();

        var actualIndex = new JumpSearcher().FindIndex(data, missingItem);
        
        Assert.AreEqual(-1, actualIndex);
    }

    [Test]
    public static void FindIndex_ArrayEmpty_MinusOneReturned([Random(-100, 1_100, 10)] int missingItem)
    {
        var actualIndex = new JumpSearcher().FindIndex(Array.Empty<int>(), missingItem);

        Assert.AreEqual(-1, actualIndex);
    }
}
