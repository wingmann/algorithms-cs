namespace Algorithms.Sorting.Comparison;

/// <summary>
/// Divide and Conquer algorithm, which splits array in two halves, calls itself for the two halves and
/// then merges the two sorted halves.
/// </summary>
public static class MergeSorter
{
    /// <summary>
    /// Sorts array using merge sort algorithm, originally designed as external sorting algorithm, internal, stable.
    /// Time complexity: O(n log(n)), space complexity: O(n), where n - array length.
    /// </summary>
    /// <param name="array">Array to sort.</param>
    /// <param name="comparer">Comparer to compare elements of <paramref name="array" />.</param>
    /// <typeparam name="T">Type of array elements.</typeparam>
    public static void Sort<T>(T[] array, IComparer<T> comparer)
        where T : IComparable<T>
    {
        if (array.Length <= 1)
        {
            return;
        }

        var (left, right) = Split(array);
        
        Sort(left, comparer);
        Sort(right, comparer);
        Merge(array, left, right, comparer);
    }
    
    private static void Merge<T>(IList<T> array, IReadOnlyList<T> left, IReadOnlyList<T> right, IComparer<T> comparer)
        where T : IComparable<T>
    {
        var mainIndex = 0;
        var leftIndex = 0;
        var rightIndex = 0;

        while (leftIndex < left.Count && rightIndex < right.Count)
        {
            var compResult = comparer.Compare(left[leftIndex], right[rightIndex]);
            array[mainIndex++] = compResult <= 0 ? left[leftIndex++] : right[rightIndex++];
        }

        while (leftIndex < left.Count)
        {
            array[mainIndex++] = left[leftIndex++];
        }

        while (rightIndex < right.Count)
        {
            array[mainIndex++] = right[rightIndex++];
        }
    }

    private static (T[] left, T[] right) Split<T>(IReadOnlyCollection<T> array)
        where T : IComparable<T>
    {
        var mid = array.Count / 2;
        return (array.Take(mid).ToArray(), array.Skip(mid).ToArray());
    }
}
