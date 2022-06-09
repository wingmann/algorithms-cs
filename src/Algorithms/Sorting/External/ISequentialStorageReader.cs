namespace Wingmann.Algorithms.Sorting.External;

public interface ISequentialStorageReader<out T> : IDisposable
{
    T Read();
}
