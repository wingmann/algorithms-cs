using System.Collections;
using NUnit.Framework;
using Wingmann.DataStructures.LinkedList;

namespace Wingmann.DatStuctures.Tests.LinkedList;

public static class SinglyLinkedListTests
{
    [Test]
    public static void LengthWorksCorrectly([Random(0, 1000, 100)] int quantity)
    {
        // Arrange.
        SinglyLinkedList<int> list = new();
        var randomizer = TestContext.CurrentContext.Random;

        // Act.
        for (var i = 0; i < quantity; i++)
        {
            _ = list.AddFirst(randomizer.Next());
        }

        // Assert.
        Assert.AreEqual(quantity, list.Length());
    }

    [Test]
    public static void LengthOnEmptyListIsZero()
    {
        // Arrange.
        SinglyLinkedList<int> list = new();

        // Assert.
        Assert.AreEqual(0, list.Length());
    }

    [Test]
    public static void GetItemsFromLinkedList()
    {
        // Arrange.
        SinglyLinkedList<string> testObj = new();
        _ = testObj.AddLast("H");
        _ = testObj.AddLast("E");
        _ = testObj.AddLast("L");
        _ = testObj.AddLast("L");
        _ = testObj.AddLast("O");

        // Act.
        var items = testObj.GetListData();

        // Assert.
        Assert.AreEqual(5, items.Count());
        Assert.AreEqual("O", testObj.GetElementByIndex(4));
    }

    [Test]
    public static void GetElementByIndex_IndexOutOfRange_ArgumentOutOfRangeExceptionThrown()
    {
        // Arrange.
        SinglyLinkedList<int> list = new();

        // Act.
        _ = list.AddFirst(1);
        _ = list.AddFirst(2);
        _ = list.AddFirst(3);

        // Assert.
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => list.GetElementByIndex(-1));
        _ = Assert.Throws<ArgumentOutOfRangeException>(() => list.GetElementByIndex(3));
    }

    [Test]
    public static void RemoveItemsFromList()
    {
        // Arrange.
        SinglyLinkedList<string> testObj = new();
        _ = testObj.AddLast("X");
        _ = testObj.AddLast("H");
        _ = testObj.AddLast("E");
        _ = testObj.AddLast("L");
        _ = testObj.AddLast("L");
        _ = testObj.AddLast("I");
        _ = testObj.AddLast("O");
        
        // Act.
        BitArray array = new(7)
        {
            [0] = testObj.DeleteElement("X"),
            [1] = testObj.DeleteElement("O"),
            [2] = testObj.DeleteElement("E"),
            [3] = testObj.DeleteElement("L"),
            [4] = testObj.DeleteElement("L"),
            [5] = testObj.DeleteElement("L"),
            [6] = testObj.DeleteElement("F"),
        };
        
        var result = $"{testObj.GetElementByIndex(0)}{testObj.GetElementByIndex(1)}";
        
        // Assert.
        Assert.AreEqual("HI", result);
        
        Assert.IsTrue(array[0]);
        Assert.IsTrue(array[1]);
        Assert.IsTrue(array[2]);
        Assert.IsTrue(array[3]);
        Assert.IsTrue(array[4]);
        Assert.IsFalse(array[5]);
        Assert.IsFalse(array[6]);
    }
}
