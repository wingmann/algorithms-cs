﻿using NUnit.Framework;

namespace Wingmann.Algorithms.Tests.Search.Helpers;

public class Helper
{
    public static int[] GetSortedArray(int length) =>
        Enumerable
            .Range(0, length)
            .Select(_ => TestContext.CurrentContext.Random.Next(1_000_000))
            .OrderBy(x => x)
            .ToArray();

    public static int GetItemIn(int[] arr) => arr[TestContext.CurrentContext.Random.Next(arr.Length)];

    public static int GetItemNotIn(int[] arr)
    {
        int item;
        
        do
        {
            item = TestContext.CurrentContext.Random.Next(arr.Min(), arr.Max() + 1);
        }
        
        while (arr.Contains(item));

        return item;
    }

    public static int GetItemSmallerThanAllIn(IEnumerable<int> arr) => arr.Min() - 1;

    public static int GetItemBiggerThanAllIn(IEnumerable<int> arr) => arr.Max() + 1;
}
