namespace Algorithms.Sorting.Comparison;

public interface IComparisonSorter<T>
    where T: IComparable<T>
{
    void Sort(T[] array, IComparer<T> comparer);
}
