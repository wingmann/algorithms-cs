using NUnit.Framework;
using Wingmann.Algorithms.Sorting.Comparison.Additional;
using Wingmann.Algorithms.Tests.Helpers;

namespace Wingmann.Algorithms.Tests.Sorting.Comparison;

public static class CocktailSorterTests
{
    [Test]
    public static void SortArrays([Random(0, 1_000, 100, Distinct = true)] int n)
    {
        // Arrange.
        CocktailSorter sorter = new();
        var (testArray, correctArray) = RandomHelper.GetArrays(n);
        
        // Act.
        sorter.Sort(testArray, new IntegralComparer());
        Array.Sort(correctArray);
        
        // Assert.
        Assert.AreEqual(testArray, correctArray);
    }
}
