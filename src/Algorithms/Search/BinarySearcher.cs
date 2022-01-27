namespace Algorithms.Search;

/// <summary>
/// Implements binary search algorithm.
/// </summary>
public static class BinarySearcher
{
    /// <summary>
    /// Finds index of item in array that equals to item searched for.
    /// Time complexity: O(log(n)), space complexity: O(1), where n - array size.
    /// </summary>
    /// <param name="sortedData">Sorted array to search in.</param>
    /// <param name="item">Item to search for.</param>
    /// <typeparam name="T">Type of array item.</typeparam>
    /// <returns>Index of item that equals to item searched for or -1 if none found.</returns>
    public static int FindIndex<T>(T[] sortedData, T item) where T : IComparable<T>
    {
        var leftIndex = 0;
        var rightIndex = sortedData.Length - 1;

        while (leftIndex <= rightIndex)
        {
            var middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

            switch (item.CompareTo(sortedData[middleIndex]))
            {
                case > 0:
                    leftIndex = middleIndex + 1;
                    continue;
                case < 0:
                    rightIndex = middleIndex - 1;
                    continue;
                default:
                    return middleIndex;
            }
        }

        return -1;
    }
}
