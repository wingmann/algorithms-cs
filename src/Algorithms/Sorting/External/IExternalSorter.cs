namespace Wingmann.Algorithms.Sorting.External;

public interface IExternalSorter
{
    /// <summary>
    /// Sorts elements in sequential storage in ascending order.
    /// </summary>
    /// <param name="mainMemory">Memory that contains array to sort and will contain the result.</param>
    /// <param name="temporaryMemory">Temporary memory for working purposes.</param>
    /// <param name="comparer"></param>
    /// <typeparam name="T">Type of array element.</typeparam>
    void Sort<T>(ISequentialStorage<T> mainMemory, ISequentialStorage<T> temporaryMemory, IComparer<T> comparer);
}
