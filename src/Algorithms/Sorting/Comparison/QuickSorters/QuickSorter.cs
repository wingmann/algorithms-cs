namespace Algorithms.Sorting.Comparison.QuickSorters;

/// <summary>
/// Implements quicksort algorithm.
/// <see href="https://en.wikipedia.org/wiki/Quicksort" />
/// </summary>
public abstract class QuickSorter : IComparisonSorter
{
    /// <inheritdoc cref="IComparisonSorter.Sort{T}" />
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T> =>
        Sort(array, comparer, 0, array.Length - 1);

    protected abstract T SelectPivot<T>(T[] array, IComparer<T> comparer, int left, int right);

    private void Sort<T>(T[] array, IComparer<T> comparer, int left, int right) where T : IComparable<T>
    {
        while (true)
        {
            if (left >= right)
            {
                return;
            }

            var p = Partition(array, comparer, left, right);
            
            Sort(array, comparer, left, p);
            left = p + 1;
        }
    }

    private int Partition<T>(T[] array, IComparer<T> comparer, int leftInput, int rightInput)
    {
        var pivot = SelectPivot(array, comparer, leftInput, rightInput);
        var left = leftInput;
        var right = rightInput;
        
        while (true)
        {
            while (comparer.Compare(array[left], pivot) < 0)
            {
                left++;
            }

            while (comparer.Compare(array[right], pivot) > 0)
            {
                right--;
            }

            if (left >= right)
            {
                return right;
            }

            (array[left], array[right]) = (array[right], array[left]);

            left++;
            right--;
        }
    }
}
