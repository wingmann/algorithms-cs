using Algorithms.Search.Interfaces;

namespace Algorithms.Search;

/// <summary>
/// Implements binary search algorithm.<br />
/// See <see href="https://en.wikipedia.org/wiki/Binary_search_algorithm" />.
/// </summary>
public class BinarySearcher : ISearchAlgorithm
{
    /// <inheritdoc cref="ISearchAlgorithm.FindIndex{T}" />
    public int FindIndex<T>(T[] data, T item) where T : IComparable<T>
    {
        var leftIndex = 0;
        var rightIndex = data.Length - 1;

        while (leftIndex <= rightIndex)
        {
            var middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

            switch (item.CompareTo(data[middleIndex]))
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
