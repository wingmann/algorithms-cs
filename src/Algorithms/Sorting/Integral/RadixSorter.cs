using Algorithms.Sorting.Integral.Interfaces;

namespace Algorithms.Sorting.Integral;

/// <summary>
/// Radix sort is a non-comparative integer sorting algorithm that sorts data with integer keys by grouping keys by the
/// individual digits which share the same significant position and value.
/// A positional notation is required, but because integers can represent strings of characters (e.g., names or dates)
/// and specially formatted floating point numbers, radix sort is not limited to integers.
/// </summary>
public class RadixSorter : IIntegralSorter
{
    /// <summary>
    /// Sorts array in ascending order.
    /// </summary>
    /// <param name="array">Array to sort.</param>
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
