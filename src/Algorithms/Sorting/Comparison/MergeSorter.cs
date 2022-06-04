using Algorithms.Sorting.Comparison.Interfaces;

namespace Algorithms.Sorting.Comparison;

/// <summary>
/// Divide and Conquer algorithm, which splits array in two halves, calls itself for the two halves and
/// then merges the two sorted halves.<br />
/// See <see href="https://en.wikipedia.org/wiki/Merge_sort" />.
/// </summary>
public class MergeSorter : IComparisonSorter
{
    /// <inheritdoc cref="IComparisonSorter.Sort{T}" />
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T>
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
    {
        var middle = array.Count / 2;
        return (array.Take(middle).ToArray(), array.Skip(middle).ToArray());
    }
}
