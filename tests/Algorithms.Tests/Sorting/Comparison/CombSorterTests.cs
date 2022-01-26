using Algorithms.Sorting.Comparison.Additional;
using Algorithms.Tests.Helpers;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting.Comparison;

public static class CombSorterTests
{
    [Test]
    public static void SortArrays_WithDefaultShrinkFactor([Random(0, 1_000, 100, Distinct = true)] int n)
    {
        // Arrange.
        CombSorter sorter = new(null);
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
        CombSorter sorter = new(1.5);
        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act.
        sorter.Sort(testArray, new IntegralComparer());
        Array.Sort(correctArray);

        // Assert.
        Assert.AreEqual(testArray, correctArray);
    }
}
