using NUnit.Framework;
using Wingmann.Algorithms.Sorting.Comparison;
using Wingmann.Algorithms.Tests.Helpers;

namespace Wingmann.Algorithms.Tests.Sorting.Comparison;

public static class SelectionSorterTests
{
    [Test]
    public static void SortArrays([Random(0, 1_000, 100, Distinct = true)] int n)
    {
        // Arrange
        SelectionSorter sorter = new();
        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act
        sorter.Sort(testArray, new IntegralComparer());
        Array.Sort(correctArray);

        // Assert
        Assert.AreEqual(testArray, correctArray);
    }
}
