using Algorithms.Sorting.Comparison;
using Algorithms.Tests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Algorithms.Tests.Sorting.Comparison;

public static class SelectionSorterTests
{
    [Test]
    public static void SortArray([Random(0, 1000, 100, Distinct = true)] int n)
    {
        // Arrange
        IComparisonSorter<int> sorter = new SelectionSorter<int>();
        IComparer<int> comparer = new IntegralComparer();

        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act
        sorter.Sort(testArray, comparer);
        Array.Sort(correctArray);

        // Assert
        Assert.AreEqual(testArray, correctArray);
    }
}
