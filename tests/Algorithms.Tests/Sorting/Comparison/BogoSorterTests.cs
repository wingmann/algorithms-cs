using NUnit.Framework;
using Wingmann.Algorithms.Sorting.Comparison.Additional;
using Wingmann.Algorithms.Tests.Helpers;

namespace Wingmann.Algorithms.Tests.Sorting.Comparison;

public static class BogoSorterTests
{
    [Test]
    public static void SortArrays([Random(0, 10, 10, Distinct = true)] int n)
    {
        // Arrange.
        BogoSorter sorter = new();
        var (testArray, correctArray) = RandomHelper.GetArrays(n);
        
        // Act.
        sorter.Sort(testArray, new IntegralComparer());
        Array.Sort(correctArray);
        
        // Assert.
        Assert.AreEqual(testArray, correctArray);
    }
}
