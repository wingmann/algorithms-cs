using Algorithms.Sorting.Comparison;
using Algorithms.Sorting.Comparison.Interfaces;
using Algorithms.Tests.Helpers;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting.Comparison;

public static class CombSorterTests
{
    [Test]
    public static void SortArrays_WithDefaultShrinkFactor([Random(0, 1_000, 100, Distinct = true)] int n)
    {
        // Arrange.
        IComparisonSorter sorter = new CombSorter(null);
        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act.
        sorter.Sort(testArray, new IntegralComparer());
        Array.Sort(correctArray);

        // Assert.
        Assert.AreEqual(testArray, correctArray);
    }

    [Test]
    public static void SortArrays_WithCustomShrinkFactor([Random(0, 1_000, 100, Distinct = true)] int n)
    {
        // Arrange.
        var sorter = new CombSorter(1.5);
        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act.
        sorter.Sort(testArray, new IntegralComparer());
        Array.Sort(correctArray);

        // Assert.
        Assert.AreEqual(testArray, correctArray);
    }
}
