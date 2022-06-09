namespace Wingmann.Algorithms.Sorting.Comparison;

/// <summary>
/// Implements binary insertion sort algorithm.
/// See on <see href="https://www.geeksforgeeks.org/binary-insertion-sort">GeeksForGeeks</see>.
/// </summary>
public class BinaryInsertionSorter : IComparisonSorter
{
    /// <inheritdoc cref="IComparisonSorter.Sort{T}"/>
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T>
    {
        for (var i = 1; i < array.Length; i++)
        {
            var target = array[i];
            var moveIndex = i - 1;
            var targetInsertLocation = BinarySearch(array, 0, moveIndex, target, comparer);
            
            Array.Copy(array, targetInsertLocation, array, targetInsertLocation + 1, i - targetInsertLocation);
            array[targetInsertLocation] = target;
        }
    }
    
    private static int BinarySearch<T>(IReadOnlyList<T> array, int from, int to, T target, IComparer<T> comparer)
    {
        var left = from;
        var right = to;
        
        while (right > left)
        {
            var middle = (left + right) / 2;
            var result = comparer.Compare(target, array[middle]);

            switch (result)
            {
                case 0:
                    return middle + 1;
                case > 0:
                    left = middle + 1;
                    break;
                default:
                    right = middle - 1;
                    break;
            }
        }

        return comparer.Compare(target, array[left]) < 0 ? left : left + 1;
    }
}
