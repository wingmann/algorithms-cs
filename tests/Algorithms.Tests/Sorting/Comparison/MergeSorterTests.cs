using Algorithms.Sorting.Comparison;
using Algorithms.Tests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Algorithms.Tests.Sorting.Comparison;

/// <summary>
/// Class for testing merge sorter algorithm.
/// </summary>
public static class MergeSorterTests
{
    [Test]
    public static void SortArray([Random(0, 1000, 100, Distinct = true)] int n)
    {
        // Arrange
        IComparisonSorter<int> sorter = new MergeSorter<int>();
        IComparer<int> comparer = new IntegralComparer();

        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act
        sorter.Sort(testArray, comparer);
        Array.Sort(correctArray);

        // Assert
        Assert.AreEqual(correctArray, testArray);
    }
}
