using Algorithms.Sorting.Comparison.Interfaces;

namespace Algorithms.Sorting.Comparison.Additional;

/// <summary>
/// Implements shell sort algorithm.
/// </summary>
public class ShellSorter : IComparisonSorter
{
    /// <inheritdoc cref="IComparisonSorter.Sort{T}" />
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T>
    {
        for (var step = array.Length / 2; step > 0; step /= 2)
        {
            for (var i = 0; i < step; i++)
            {
                GapBubbleSort(array, comparer, i, step);
            }
        }
    }
    
    private static void GapBubbleSort<T>(IList<T> array, IComparer<T> comparer, int start, int step)
    {
        for (var j = start; j < array.Count - step; j += step)
        {
            var wasChanged = false;
            
            for (var k = start; k < array.Count - j - step; k += step)
            {
                if (comparer.Compare(array[k], array[k + step]) <= 0)
                {
                    continue;
                }
                
                (array[k], array[k + step]) = (array[k + step], array[k]);
                wasChanged = true;
            }

            if (wasChanged is false)
            {
                break;
            }
        }
    }
}
