using Algorithms.Sorting.Comparison;
using Algorithms.Tests.Helpers;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting.Comparison;

public static class BinaryInsertionSorterTests
{
    [Test]
    public static void SortArrays([Random(0, 1000, 100, Distinct = true)] int n)
    {
        // Arrange
        IComparisonSorter sorter = new BinaryInsertionSorter();
        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act
        sorter.Sort(testArray, new IntegralComparer());
        Array.Sort(correctArray);

        // Assert
        Assert.AreEqual(testArray, correctArray);
    }
}
