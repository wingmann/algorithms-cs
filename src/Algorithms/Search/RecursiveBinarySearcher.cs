using Algorithms.Search.Interfaces;

namespace Algorithms.Search;

/// <summary>
/// Recursive binary search algorithm.
/// </summary>
public class RecursiveBinarySearcher : ISearchAlgorithm
{
    /// <summary>
    /// Finds the index of first occurrence of the target item.
    /// </summary>
    /// <param name="data">Array where the element should be found.</param>
    /// <param name="item">Element which should be found.</param>
    /// <typeparam name="T">Comparable type.</typeparam>
    /// <returns>Index of the first occurrence of the target element, or -1 if it is not found.</returns>
    public int FindIndex<T>(T[] data, T item) where T : IComparable<T> => data.Length switch
    {
        0 => -1,
        _ => FindIndex(data, item, 0, data.Length - 1),
    };

    private static int FindIndex<T>(IReadOnlyList<T> data, T item, int leftIndex, int rightIndex)
        where T : IComparable<T>
    {
        if (leftIndex > rightIndex)
        {
            return -1;
        }

        var middleIndex = leftIndex + (rightIndex - leftIndex) / 2;
        var result = item.CompareTo(data[middleIndex]);

        return result switch
        {
            0 => middleIndex,
            > 0 => FindIndex(data, item, middleIndex + 1, rightIndex),
            < 0 => FindIndex(data, item, leftIndex, middleIndex - 1),
        };
    }
}
