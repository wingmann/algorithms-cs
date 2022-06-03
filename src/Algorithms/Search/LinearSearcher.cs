using Algorithms.Search.Interfaces;

namespace Algorithms.Search;

/// <summary>
/// Implements linear search algorithm.
/// <see href="https://en.wikipedia.org/wiki/Linear_search" />
/// </summary>
public class LinearSearcher : ISearchAlgorithm
{
    /// <inheritdoc cref="ISearchAlgorithm.FindIndex{T}"/>>
    public int FindIndex<T>(T[] data, T item) where T : IComparable<T>
    {
        for (var i = 0; i < data.Length; i++)
        {
            if (item.CompareTo(data[i]) is 0)
            {
                return i;
            }
        }

        return -1;
    }
}
