using Algorithms.Search;
using Algorithms.Tests.Search.Helpers;
using NUnit.Framework;

namespace Algorithms.Tests.Search;

public static class FastSearcherTests
{
    [Test]
    public static void FindIndex_ItemPresent_IndexCorrect()
    {
        // Arrange.
        var arr = Helper.GetSortedArray(1_000);
        var present = Helper.GetItemIn(arr);
        
        // Act.
        var index = FastSearcher.FindIndex(arr, present);
        
        // Assert.
        Assert.AreEqual(present, arr[index]);
    }

    [TestCase(new[] { 1, 2 }, 1)]
    [TestCase(new[] { 1, 2 }, 2)]
    [TestCase(new[] { 1, 2, 3, 3, 3 }, 2)]
    public static void FindIndex_ItemPresentInSpecificCase_IndexCorrect(int[] arr, int present) =>
        Assert.AreEqual(present, arr[FastSearcher.FindIndex(arr, present)]);

    [Test]
    public static void FindIndex_ItemMissing_ItemNotFoundExceptionThrown()
    {
        var arr = Helper.GetSortedArray(1000);
        var missing = Helper.GetItemNotIn(arr);
        
        _ = Assert.Throws<ApplicationException>(() => FastSearcher.FindIndex(arr, missing));
    }

    [TestCase(new int[0], 2)]
    public static void FindIndex_ItemMissingInSpecificCase_ItemNotFoundExceptionThrown(int[] arr, int missing) =>
        _ = Assert.Throws<ApplicationException>(() => FastSearcher.FindIndex(arr, missing));

    [Test]
    public static void FindIndex_ItemSmallerThanAllMissing_ItemNotFoundExceptionThrown()
    {
        var arr = Helper.GetSortedArray(1_000);
        var missing = Helper.GetItemSmallerThanAllIn(arr);
        
        _ = Assert.Throws<ApplicationException>(() => FastSearcher.FindIndex(arr, missing));
    }

    [Test]
    public static void FindIndex_ItemBiggerThanAllMissing_ItemNotFoundExceptionThrown()
    {
        var arr = Helper.GetSortedArray(1_000);
        var missing = Helper.GetItemBiggerThanAllIn(arr);
        
        _ = Assert.Throws<ApplicationException>(() => FastSearcher.FindIndex(arr, missing));
    }

    [Test]
    public static void FindIndex_ArrayOfDuplicatesItemPresent_IndexCorrect()
    {
        // Arrange.
        var arr = new int[1_000];
        const int present = 0;
        
        // Act.
        var index = FastSearcher.FindIndex(arr, present);
        
        // Assert.
        Assert.AreEqual(0, arr[index]);
    }

    [Test]
    public static void FindIndex_ArrayOfDuplicatesItemMissing_ItemNotFoundExceptionThrown()
    {
        var arr = new int[1_000];
        const int missing = 1;
        
        _ = Assert.Throws<ApplicationException>(() => FastSearcher.FindIndex(arr, missing));
    }
}
