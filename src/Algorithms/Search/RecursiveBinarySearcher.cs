namespace Algorithms.Search;

/// <inheritdoc cref="BinarySearcher" />
public class RecursiveBinarySearcher : ISearchAlgorithm
{
    /// <inheritdoc cref="ISearchAlgorithm.FindIndex{T}" />
    public int FindIndex<T>(T[] data, T item) where T : IComparable<T> =>
        FindIndex(data, item, 0, data.Length - 1);
    
    private static int FindIndex<T>(IReadOnlyList<T> data, T item, int leftIndex, int rightIndex)
        where T : IComparable<T>
    {
        if (leftIndex > rightIndex)
        {
            return -1;
        }

        var middleIndex = leftIndex + (rightIndex - leftIndex) / 2;

        return item.CompareTo(data[middleIndex]) switch
        {
            0 => middleIndex,
            > 0 => FindIndex(data, item, middleIndex + 1, rightIndex),
            < 0 => FindIndex(data, item, leftIndex, middleIndex - 1),
        };
    }
}