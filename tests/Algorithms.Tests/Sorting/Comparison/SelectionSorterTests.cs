﻿using Algorithms.Sorting.Comparison;
using Algorithms.Tests.Helpers;
using NUnit.Framework;
using System;

namespace Algorithms.Tests.Sorting.Comparison;

public static class SelectionSorterTests
{
    [Test]
    public static void SortArray([Random(0, 1000, 100, Distinct = true)] int n)
    {
        // Arrange
        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act
        SelectionSorter.Sort(testArray, new IntegralComparer());
        Array.Sort(correctArray);

        // Assert
        Assert.AreEqual(testArray, correctArray);
    }
}
