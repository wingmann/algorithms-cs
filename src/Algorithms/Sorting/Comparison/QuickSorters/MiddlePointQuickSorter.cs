namespace Wingmann.Algorithms.Sorting.Comparison.QuickSorters;

/// <summary>
/// Sorts arrays using quicksort (selecting middle point as a pivot).
/// </summary>
public class MiddlePointQuickSorter : QuickSorter
{
    protected override T SelectPivot<T>(T[] array, IComparer<T> comparer, int left, int right) =>
        array[left + (right - left) / 2];
}
