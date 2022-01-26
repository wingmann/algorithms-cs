using Algorithms.Sorting.Comparison;
using Algorithms.Tests.Helpers;
using NUnit.Framework;

namespace Algorithms.Tests.Sorting.Comparison;

public static class TimSorterTests
{
    [Test]
    public static void SortArrays([Random(0, 1000, 100, Distinct = true)] int n)
    {
        // Arrange.
        TimSorter sorter = new();
        var (correctArray, testArray) = RandomHelper.GetArrays(n);

        // Act.
        sorter.Sort(testArray, new IntegralComparer());
        Array.Sort(correctArray);

        // Assert.
        Assert.AreEqual(testArray, correctArray);
    }

    [Test]
    public static void TinyArray()
    {
        // Arrange.
        TimSorter sorter = new();
        var tinyArray = new[] {1};
        var correctArray = new[] {1};

        // Act.
        sorter.Sort(tinyArray, new IntegralComparer());

        // Assert.
        Assert.AreEqual(tinyArray, correctArray);
    }

    [Test]
    public static void SmallChunks()
    {
        // Arrange.
        TimSorter sorter = new();
        var (correctArray, testArray) = RandomHelper.GetArrays(800);
        
        Array.Sort(correctArray);
        Array.Sort(testArray);

        testArray[0] = correctArray[0] = testArray.Max();
        testArray[799] = correctArray[799] = testArray.Min();

        // Act.
        sorter.Sort(testArray, new IntegralComparer());
        Array.Sort(correctArray);

        // Assert.
        Assert.AreEqual(testArray, correctArray);
    }
}
