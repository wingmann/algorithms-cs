using Algorithms.Sorting.Integral.Interfaces;

namespace Algorithms.Sorting.Integral;

/// <summary>
/// Implements radix sorting algorithm.
/// See on <see href="https://en.wikipedia.org/wiki/Radix_sort">Wikipedia</see>.
/// </summary>
public class RadixSorter : IIntegralSorter
{
    /// <inheritdoc cref="IIntegralSorter.Sort" />
    public void Sort(int[] array)
    {
        const int bits = 4;
        
        var b = new int[array.Length];
        var rightShift = 0;
        
        for (var mask = ~(-1 << bits); mask is not 0; mask <<= bits, rightShift += bits)
        {
            var countArray = new int[1 << bits];
            
            foreach (var t in array)
            {
                var key = (t & mask) >> rightShift;
                ++countArray[key];
            }

            for (var i = 1; i < countArray.Length; ++i)
            {
                countArray[i] += countArray[i - 1];
            }

            for (var p = array.Length - 1; p >= 0; --p)
            {
                var key = (array[p] & mask) >> rightShift;
                b[--countArray[key]] = array[p];
            }

            (b, array) = (array, b);
        }
    }
}
