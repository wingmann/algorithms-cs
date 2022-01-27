using Algorithms.Sorting.Integral;
using Algorithms.Tests.Helpers;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting.Integral;

public static class BucketSorterTests
{
    [Test]
    public static void SortArrays([Random(0, 1_000, 1_000, Distinct = true)] int n)
    {
        // Arrange.
        BucketSorter sorter = new();
        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act.
        sorter.Sort(testArray);
        Array.Sort(correctArray);

        // Assert.
        Assert.AreEqual(correctArray, testArray);
    }
}
