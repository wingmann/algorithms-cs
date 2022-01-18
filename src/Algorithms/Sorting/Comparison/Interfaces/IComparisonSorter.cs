namespace Algorithms.Sorting.Comparison.Interfaces;

public interface IComparisonSorter
{
    public void Sort<T>(T[] array, IComparer<T> comparer) where T : IComparable<T>;
}
