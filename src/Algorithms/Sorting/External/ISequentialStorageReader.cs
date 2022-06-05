namespace Algorithms.Sorting.External;

public interface ISequentialStorageReader<out T> : IDisposable
{
    T Read();
}
