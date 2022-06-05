using Algorithms.Sorting.Integral.Interfaces;

namespace Algorithms.Sorting.Integral;

/// <summary>
/// Implements counting sorting algorithm.
/// See on <see href="https://en.wikipedia.org/wiki/Counting_sort">Wikipedia</see>.
/// </summary>
public class CountingSorter : IIntegralSorter
{
    /// <inheritdoc cref="IIntegralSorter.Sort" />
    public void Sort(int[] array)
    {
        if (array.Length is 0)
        {
            return;
        }
        
        var min = array.Min();
        var count = new int[array.Max() - min + 1];
        var output = new int[array.Length];
        
        foreach (var t in array)
        {
            count[t - min]++;
        }

        for (var i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }

        for (var i = array.Length - 1; i >= 0; i--)
        {
            output[count[array[i] - min] - 1] = array[i];
            count[array[i] - min]--;
        }

        Array.Copy(output, array, array.Length);
    }
}
