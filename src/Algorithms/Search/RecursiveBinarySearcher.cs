using Algorithms.Search.Interfaces;

namespace Algorithms.Search;

/// <summary>
/// Implements binary search algorithm.
/// <see href="https://en.wikipedia.org/wiki/Binary_search_algorithm" />
/// </summary>
public class RecursiveBinarySearcher : ISearchAlgorithm
{
    /// <inheritdoc cref="ISearchAlgorithm.FindIndex{T}"/>>
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
