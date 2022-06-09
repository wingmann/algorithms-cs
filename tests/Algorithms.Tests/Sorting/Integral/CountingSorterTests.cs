using NUnit.Framework;
using Wingmann.Algorithms.Sorting.Integral;
using Wingmann.Algorithms.Tests.Helpers;

namespace Wingmann.Algorithms.Tests.Sorting.Integral;

public static class CountingSorterTests
{
    [Test]
    public static void SortArrays([Random(1, 10_000, 100, Distinct = true)] int n)
    {
        // Arrange.
        CountingSorter sorter = new();
        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act.
        sorter.Sort(testArray);
        Array.Sort(correctArray);

        // Assert.
        Assert.AreEqual(correctArray, testArray);
    }

    [Test]
    public static void SortEmptyArray() => new CountingSorter().Sort(Array.Empty<int>());
}
