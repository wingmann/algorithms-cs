using DataStructures.LinkedList;
using NUnit.Framework;

namespace DataStructures.Tests.LinkedList;

public static class DoublyLinkedListTests
{
    [Test]
    public static void TestGetData()
    {
        // Arrange.
        DoublyLinkedList<int> list = new(new[] { 0, 1, 2, 3, 4 });
        
        // Act.
        var arr = list.GetData().ToArray();

        // Assert.
        Assert.AreEqual(list.Count, 5);
        Assert.AreEqual(new[] { 0, 1, 2, 3, 4 }, arr);
    }

    [Test]
    public static void TestGetAt()
    {
        // Arrange.
        var list = new DoublyLinkedList<int>(new[] { 0, 1, 2, 3, 4 });

        // Act.
        var values = new[]
        {
            list.GetAt(1),
            list.GetAt(3),
        };

        // Assert.
        Assert.AreEqual(values[0].Data, 1);
        Assert.AreEqual(values[1].Data, 3);
        
        Assert.Throws<ArgumentOutOfRangeException>(() => list.GetAt(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => list.GetAt(5));
    }

    [Test]
    public static void TestAddition()
    {
        // Arrange.
        DoublyLinkedList<int> list = new(0);
        
        // Act.
        var first = list.Add(1);
        list.Add(3);
        list.AddAfter(2, first);
        list.Add(4);

        var array = list.GetData().ToArray();

        // Assert.
        Assert.AreEqual(list.Count, 5);
        Assert.AreEqual(new[] { 0, 1, 2, 3, 4 }, array);
    }

    [Test]
    public static void TestRemove()
    {
        // Arrange.
        DoublyLinkedList<int> list = new(new[] { 0, 1, 2, 3, 4 });

        // Act.
        list.RemoveNode(list.Find(2));
        list.RemoveHead();
        list.Remove();

        var arr = list.GetData().ToArray();

        // Assert.
        Assert.AreEqual(list.Count, 2);
        Assert.AreEqual(new[] { 1, 3 }, arr);
    }

    [Test]
    public static void TestFind()
    {
        // Arrange.
        DoublyLinkedList<int> list = new(new[] { 0, 1, 2, 3, 4 });
        
        // Act.
        var values = new[]
        {
            list.Find(1),
            list.Find(3),
        };

        // Assert.
        Assert.AreEqual(values[0].Data, 1);
        Assert.AreEqual(values[1].Data, 3);
    }

    [Test]
    public static void TestIndexOf()
    {
        // Arrange.
        DoublyLinkedList<int> list = new(new[] { 0, 1, 2, 3, 4 });
        
        // Act.
        var values = new[]
        {
            list.IndexOf(1),
            list.IndexOf(3),
        };

        // Assert.
        Assert.AreEqual(values[0], 1);
        Assert.AreEqual(values[1], 3);
    }

    [Test]
    public static void TestContains()
    {
        // Arrange.
        DoublyLinkedList<int> list = new(new[] { 0, 1, 2, 3, 4 });

        // Act.
        var values = new[]
        {
            list.Contains(1),
            list.Contains(6),
        };

        // Assert.
        Assert.IsTrue(values[0]);
        Assert.IsFalse(values[1]);
    }

    [Test]
    public static void TestReverse()
    {
        // Arrange.
        DoublyLinkedList<int> list = new(new[] { 0, 1, 2, 3, 4 });
        DoublyLinkedList<int> emptyList = new(Array.Empty<int>());
        
        // Act.
        list.Reverse();
        emptyList.Reverse();
        
        var array = list.GetData().ToArray();
        var emptyArray = emptyList.GetData().ToArray();

        // Assert.
        Assert.AreEqual(array, new[] { 4, 3, 2, 1, 0 });
        Assert.AreEqual(emptyArray, Array.Empty<int>());
    }

    [Test]
    public static void TestGetDataReversed()
    {
        // Arrange.
        DoublyLinkedList<int> list = new(new[] { 0, 1, 2, 3, 4 });
        
        // Act.
        var array = list.GetData().ToArray();
        var reversedArray = list.GetDataReversed().ToArray();

        // Assert.
        Assert.AreEqual(array, new[] { 0, 1, 2, 3, 4 });
        Assert.AreEqual(reversedArray, new[] { 4, 3, 2, 1, 0 });
    }
}
