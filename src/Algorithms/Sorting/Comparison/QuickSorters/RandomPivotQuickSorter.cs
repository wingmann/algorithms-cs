namespace Algorithms.Sorting.Comparison.QuickSorters;

/// <summary>
/// Sorts arrays using quicksort (selecting random point as a pivot).
/// </summary>
public sealed class RandomPivotQuickSorter : QuickSorter
{
    private readonly Random _random = new();

    protected override T SelectPivot<T>(T[] array, IComparer<T> comparer, int left, int right) =>
        array[_random.Next(left, right + 1)];
}
