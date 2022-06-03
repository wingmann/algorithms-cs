namespace Algorithms.Sorting.Comparison.Interfaces;

/// <summary>
/// Common interface of most sorting algorithms.
/// </summary>
public interface IComparisonSorter
{
    /// <summary>
    /// Sorts array using specified comparer.
    /// </summary>
    /// <param name="data">Array to sort.</param>
    /// <param name="comparer">Compares elements.</param>
    /// <typeparam name="T">Type of array element.</typeparam>
    public void Sort<T>(T[] data, IComparer<T> comparer) where T : IComparable<T>;
}
