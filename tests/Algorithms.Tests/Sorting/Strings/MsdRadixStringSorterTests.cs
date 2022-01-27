using Algorithms.Sorting.Strings;
using Algorithms.Tests.Helpers;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting.Strings;

public static class MsdRadixStringSorterTests
{
    [Test]
    public static void ArraySorted([Random(2, 1_000, 100, Distinct = true)] int n)
    {
        // Arrange.
        MsdRadixStringSorter sorter = new();
        var (correctArray, testArray) = RandomHelper.GetStringArrays(n, 100, false);

        // Act.
        sorter.Sort(testArray);
        Array.Sort(correctArray);

        // Assert.
        Assert.AreEqual(correctArray, testArray);
    }
}
