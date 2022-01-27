namespace Algorithms.Sorting.Integral.Interfaces;

/// <summary>
/// Sorts array of integers without comparing them.
/// </summary>
public interface IIntegralSorter
{
    /// <summary>
    /// Sorts array in ascending order.
    /// </summary>
    /// <param name="array">Array to sort.</param>
    void Sort(int[] array);
}
