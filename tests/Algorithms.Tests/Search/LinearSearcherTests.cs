﻿using Algorithms.Search;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Utilities.Exceptions;

namespace Algorithms.Tests.Search;

public static class LinearSearcherTests
{
    [Test]
    public static void Find_ItemPresent_ItemCorrect([Random(0, 1_000_000, 100)] int n)
    {
        // Arrange.
        var searcher = new LinearSearcher();
        var random = Randomizer.CreateRandomizer();
        var arrayToSearch = Enumerable.Range(0, n).Select(_ => random.Next(0, 1000)).ToArray();

        // Act.
        var expectedItem = Array.Find(arrayToSearch, x => x == arrayToSearch[n / 2]);
        var actualItem = LinearSearcher.Find(arrayToSearch, x => x == arrayToSearch[n / 2]);

        // Assert.
        Assert.AreEqual(expectedItem, actualItem);
    }

    [Test]
    public static void FindIndex_ItemPresent_IndexCorrect([Random(0, 1_000_000, 100)] int n)
    {
        // Arrange.
        var searcher = new LinearSearcher();
        var random = Randomizer.CreateRandomizer();
        var arrayToSearch = Enumerable.Range(0, n).Select(_ => random.Next(0, 1_000)).ToArray();

        // Act.
        var expectedIndex = Array.FindIndex(arrayToSearch, x => x == arrayToSearch[n / 2]);
        var actualIndex = LinearSearcher.FindIndex(arrayToSearch, x => x == arrayToSearch[n / 2]);

        // Assert.
        Assert.AreEqual(expectedIndex, actualIndex);
    }

    [Test]
    public static void Find_ItemMissing_ItemNotFoundExceptionThrown([Random(0, 1_000_000, 100)] int n)
    {
        // Arrange.
        var searcher = new LinearSearcher();
        var random = Randomizer.CreateRandomizer();
        var arrayToSearch = Enumerable.Range(0, n).Select(_ => random.Next(0, 1_000)).ToArray();

        // Assert.
        _ = Assert.Throws<ItemNotFoundException>(() => LinearSearcher.Find(arrayToSearch, _ => false));
    }

    [Test]
    public static void FindIndex_ItemMissing_MinusOneReturned([Random(0, 1_000_000, 100)] int n)
    {
        // Arrange.
        var searcher = new LinearSearcher();
        var random = Randomizer.CreateRandomizer();
        var arrayToSearch = Enumerable.Range(0, n).Select(_ => random.Next(0, 1_000)).ToArray();

        // Act.
        var actualIndex = LinearSearcher.FindIndex(arrayToSearch, _ => false);

        // Assert.
        Assert.AreEqual(-1, actualIndex);
    }
}
