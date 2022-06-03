using Algorithms.Search.Interfaces;

namespace Algorithms.Search;

/// <summary>
/// Binary search algorithm.
/// </summary>
public class BinarySearcher : ISearchAlgorithm
{
    /// <summary>
    /// Finds the index of first occurrence of the target item.
    /// </summary>
    /// <param name="data">Array where the element should be found.</param>
    /// <param name="item">Element which should be found.</param>
    /// <typeparam name="T">Comparable type.</typeparam>
    /// <returns>Index of the first occurrence of the target element, or -1 if it is not found.</returns>
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
