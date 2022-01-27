using Algorithms.Sorting.Comparison;
using Algorithms.Sorting.Comparison.QuickSorters;
using Algorithms.Tests.Helpers;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting.Comparison;

public static class MedianOfThreeQuickSorterTests
{
    [Test]
    public static void SortArrays([Random(0, 1_000, 100, Distinct = true)] int n)
    {
        // Arrange.
        MedianOfThreeQuickSorter sorter = new();
        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act.
        sorter.Sort(testArray, new IntegralComparer());
        Array.Sort(correctArray);

        // Assert.
        Assert.AreEqual(testArray, correctArray);
    }
}
