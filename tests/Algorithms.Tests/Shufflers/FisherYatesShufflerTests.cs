using FluentAssertions;
using NUnit.Framework;
using Wingmann.Algorithms.Shufflers;
using Wingmann.Algorithms.Tests.Helpers;

namespace Wingmann.Algorithms.Tests.Shufflers;

public static class FisherYatesShufflerTests
{
    [Test]
    public static void ArrayShuffled_NewArrayHasSameSize([Random(0, 1_000, 100, Distinct = true)] int n)
    {
        var (correctArray, testArray) = RandomHelper.GetArrays(n);
        
        new FisherYatesShuffler().Shuffle(testArray);
        
        testArray.Length.Should().Be(correctArray.Length);
    }

    [Test]
    public static void ArrayShuffled_NewArrayHasSameValues([Random(0, 1_000, 100, Distinct = true)] int n)
    {
        var (correctArray, testArray) = RandomHelper.GetArrays(n);
        
        new FisherYatesShuffler().Shuffle(testArray);
        Array.Sort(testArray);
        Array.Sort(correctArray);
        
        testArray.Should().BeEquivalentTo(correctArray);
    }
}
