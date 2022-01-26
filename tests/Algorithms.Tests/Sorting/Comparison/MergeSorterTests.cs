using Algorithms.Sorting.Comparison;
using Algorithms.Tests.Helpers;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting.Comparison;

/// <summary>
/// Class for testing merge sorter algorithm.
/// </summary>
public static class MergeSorterTests
{
    [Test]
    public static void SortArrays([Random(0, 1_000, 100, Distinct = true)] int n)
    {
        // Arrange
        MergeSorter sorter = new();
        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act
        sorter.Sort(testArray, new IntegralComparer());
        Array.Sort(correctArray);

        // Assert
        Assert.AreEqual(correctArray, testArray);
    }
}
