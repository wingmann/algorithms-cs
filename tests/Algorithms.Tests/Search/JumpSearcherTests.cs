using Algorithms.Search;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithms.Tests.Search;

public static class JumpSearcherTests
{
    [Test]
    public static void FindIndex_ItemPresent_ItemCorrect([Random(1, 1000, 100)] int n)
    {
        // Arrange.
        var sortedArray = Enumerable
            .Range(0, n)
            .Select(_ => TestContext.CurrentContext.Random.Next(1_000_000))
            .OrderBy(x => x)
            .ToArray();
        
        var expectedIndex = TestContext.CurrentContext.Random.Next(sortedArray.Length);

        // Act.
        var actualIndex = JumpSearcher.FindIndex(sortedArray, sortedArray[expectedIndex]);

        // Assert.
        sortedArray[actualIndex].Should().Be(sortedArray[expectedIndex]);
    }

    [Test]
    public static void FindIndex_ItemMissing_MinusOneReturned(
        [Random(1, 1_000, 10)] int n,
        [Random(-100, 1100, 10)] int missingItem)
    {
        // Arrange.
        var sortedArray = Enumerable
            .Range(0, n)
            .Select(_ => TestContext.CurrentContext.Random.Next(1_000_000))
            .Where(x => x != missingItem)
            .OrderBy(x => x)
            .ToArray();
        
        const int expectedIndex = -1;

        // Act.
        var actualIndex = JumpSearcher.FindIndex(sortedArray, missingItem);

        // Assert.
        Assert.AreEqual(expectedIndex, actualIndex);
    }

    [Test]
    public static void FindIndex_ArrayEmpty_MinusOneReturned([Random(-100, 1100, 10)] int missingItem)
    {
        // Arrange.
        var sortedArray = Array.Empty<int>();
        const int expectedIndex = -1;

        // Act.
        var actualIndex = JumpSearcher.FindIndex(sortedArray, missingItem);

        // Assert.
        Assert.AreEqual(expectedIndex, actualIndex);
    }

    [TestCase(null, "abc")]
    [TestCase(new[] { "abc", "def", "ghi" }, null)]
    [TestCase(null, null)]
    public static void FindIndex_ArrayNull_ItemNull_ArgumentNullExceptionThrown(string[] sortedArray, string searchItem)
    {
        _ = Assert.Throws<ArgumentNullException>(() => JumpSearcher.FindIndex(sortedArray, searchItem));
    }
}
