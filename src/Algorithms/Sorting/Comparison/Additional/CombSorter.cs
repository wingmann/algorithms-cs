using Algorithms.Sorting.Comparison.Interfaces;

namespace Algorithms.Sorting.Comparison.Additional;

/// <summary>
/// Comb sort is a relatively simple sorting algorithm that improves on bubble sort.
/// </summary>
public class CombSorter : IComparisonSorter
{
    private double ShrinkFactor { get; }
    
    public CombSorter(double? shrinkFactor) => ShrinkFactor = shrinkFactor ?? 1.3;
    
    /// <summary>
    /// Sorts array using specified comparer, internal, in-place, unstable.
    /// Worst case performance: O(n^2), best case performance: O(n log(n)), average performance: O(n^2 / 2^p),
    /// space complexity: O(1), where n - array length and p - number of increments.
    /// </summary>
    /// <param name="array">Array to sort.</param>
    /// <param name="comparer">Compares elements.</param>
    /// <typeparam name="T">Type of array element.</typeparam>
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T>
    {
        var gap = array.Length;
        var sorted = false;
        
        while (sorted is false)
        {
            gap = (int)Math.Floor(gap / ShrinkFactor);
            
            if (gap <= 1)
            {
                gap = 1;
                sorted = true;
            }

            for (var i = 0; i < array.Length - gap; i++)
            {
                if (comparer.Compare(array[i], array[i + gap]) <= 0)
                {
                    continue;
                }
                
                (array[i], array[i + gap]) = (array[i + gap], array[i]);
                sorted = false;
            }
        }
    }
}
