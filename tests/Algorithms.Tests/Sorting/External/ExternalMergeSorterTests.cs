using NUnit.Framework;
using NUnit.Framework.Internal;
using Wingmann.Algorithms.Sorting.External;
using Wingmann.Algorithms.Sorting.External.Storages;
using Wingmann.Algorithms.Tests.Helpers;

namespace Wingmann.Algorithms.Tests.Sorting.External;

public static class ExternalMergeSorterTests
{
    [Test]
    public static void SortArrays([Random(0, 1_000, 100, Distinct = true)] int n)
    {
        // Arrange.
        ExternalMergeSorter sorter = new();
        var (correctArray, testArray) = RandomHelper.GetArrays(n);
        IntegerInMemoryStorage main = new(testArray);
        IntegerInMemoryStorage temp = new(new int[testArray.Length]);

        // Act.
        sorter.Sort(main, temp, new IntegralComparer());
        Array.Sort(correctArray);

        // Assert.
        Assert.AreEqual(testArray, correctArray);
    }

    [Test]
    public static void SortArrays_OnDisk([Random(0, 1_000, 100, Distinct = true)] int n)
    {
        // Arrange.
        ExternalMergeSorter sorter = new();
        var (correctArray, testArray) = RandomHelper.GetArrays(n);
        
        var randomizer = Randomizer.CreateRandomizer();
        var main = new IntegerFileStorage($"sorted_{randomizer.GetString(100)}", n);
        var temp = new IntegerFileStorage($"temp_{randomizer.GetString(100)}", n);
        var writer = main.GetWriter();
        
        for (var i = 0; i < n; i++)
        {
            writer.Write(correctArray[i]);
        }

        writer.Dispose();

        // Act.
        sorter.Sort(main, temp, new IntegralComparer());
        Array.Sort(correctArray);

        // Assert.
        var reader = main.GetReader();
        
        for (var i = 0; i < n; i++)
        {
            testArray[i] = reader.Read();
        }

        Assert.AreEqual(testArray, correctArray);
    }
}
