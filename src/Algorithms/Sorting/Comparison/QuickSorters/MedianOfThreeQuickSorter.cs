namespace Algorithms.Sorting.Comparison.QuickSorters;

/// <summary>
/// Sorts arrays using quicksort (selecting median of three as a pivot).
/// </summary>
public class MedianOfThreeQuickSorter : QuickSorter
{
    protected override T SelectPivot<T>(T[] array, IComparer<T> comparer, int left, int right)
    {
        var leftPoint = array[left];
        var middlePoint = array[left + (right - left) / 2];
        var rightPoint = array[right];

        return FindMedian(comparer, leftPoint, middlePoint, rightPoint);
    }
    
    private static T FindMedian<T>(IComparer<T> comparer, T a, T b, T c)
    {
        if (comparer.Compare(a, b) <= 0)
        {
            if (comparer.Compare(b, c) <= 0)
            {
                return b;
            }

            return comparer.Compare(a, c) <= 0 ? c : a;
        }

        if (comparer.Compare(b, c) >= 0)
        {
            return b;
        }

        return comparer.Compare(a, c) >= 0 ? c : a;
    }
}
