using Algorithms.Sorting.Comparison;
using Algorithms.Tests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Algorithms.Tests.Sorting.Comparison;

public static class InsertionSorterTests
{
    [Test]
    public static void ArraySorted([Random(0, 1000, 100, Distinct = true)] int n)
    {
        // Arrange.
        IComparisonSorter<int> sorter = new InsertionSorter<int>();
        IComparer<int> comparer = new IntegralComparer();

        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act.
        sorter.Sort(testArray, comparer);
        Array.Sort(correctArray, comparer);
        
        // Assert.
        Assert.AreEqual(testArray, correctArray);
    }
}
