namespace Algorithms.Search;

/// <summary>
/// Implements recursive binary search algorithm.
/// </summary>
public static class RecursiveBinarySearcher
{
    /// <summary>
    /// Finds index of item in collection that equals to item searched for.<br/>
    /// Time complexity: O(log(n)), space complexity: O(1), where n - collection size.
    /// </summary>
    /// <param name="collection">Sorted collection to search in.</param>
    /// <param name="item">Item to search for.</param>
    /// <typeparam name="T">Type of collection item.</typeparam>
    /// <returns>Index of item that equals to item searched for or -1 if none found.</returns>
    public static int FindIndex<T>(IList<T>? collection, T item) where T : IComparable<T>
    {
        if (collection is null)
        {
            throw new ArgumentNullException(nameof(collection));
        }

        const int leftIndex = 0;
        var rightIndex = collection.Count - 1;

        return FindIndex(collection, item, leftIndex, rightIndex);
    }

    private static int FindIndex<T>(IList<T> collection, T item, int leftIndex, int rightIndex)
        where T : IComparable<T>
    {
        if (leftIndex > rightIndex)
        {
            return -1;
        }

        var middleIndex = leftIndex + (rightIndex - leftIndex) / 2;
        var result = item.CompareTo(collection[middleIndex]);

        return result switch
        {
            0 => middleIndex,
            > 0 => FindIndex(collection, item, middleIndex + 1, rightIndex),
            < 0 => FindIndex(collection, item, leftIndex, middleIndex - 1),
        };
    }
}
