using NUnit.Framework;
using Wingmann.Algorithms.Strings;

namespace Wingmann.Algorithms.Tests.Strings;

public static class KmpSearcherTests
{
    [Test]
    public static void FindIndexes_ItemsPresent_PassExpected()
    {
        // Arrange.
        const string data = "ABABAcdeABA";
        const string pattern = "ABA";

        // Act.
        var expected = new[] { 0, 2, 8 };
        var actual = KmpSearcher.FindIndexes(data, pattern);

        // Assert.
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public static void FindIndexes_ItemsMissing_NoIndexesReturned()
    {
        // Arrange.
        const string data = "ABABA";
        const string pattern = "ABB";

        // Act.
        var indexes = KmpSearcher.FindIndexes(data, pattern);

        // Assert.
        Assert.IsEmpty(indexes);
    }

    [Test]
    public static void LongestPrefixSuffixArray_PrefixSuffixOfLength1_PassExpected()
    {
        // Arrange.
        const string pattern = "ABA";

        // Act.
        var expected = new[] { 0, 0, 1 };
        var actual = KmpSearcher.FindLongestPrefixSuffixValues(pattern);

        // Assert.
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public static void LongestPrefixSuffixArray_PrefixSuffixOfLength5_PassExpected()
    {
        // Arrange.
        const string pattern = "AABAACAABAA";

        // Act.
        var expected = new[] { 0, 1, 0, 1, 2, 0, 1, 2, 3, 4, 5 };
        var actual = KmpSearcher.FindLongestPrefixSuffixValues(pattern);

        // Assert.
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public static void LongestPrefixSuffixArray_PrefixSuffixOfLength0_PassExpected()
    {
        // Arrange.
        const string pattern = "AB";

        // Act.
        var expected = new[] { 0, 0 };
        var actual = KmpSearcher.FindLongestPrefixSuffixValues(pattern);

        // Assert.
        CollectionAssert.AreEqual(expected, actual);
    }
}
