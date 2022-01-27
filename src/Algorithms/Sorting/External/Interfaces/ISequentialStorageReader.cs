namespace Algorithms.Sorting.External.Interfaces;

public interface ISequentialStorageReader<out T> : IDisposable
{
    T Read();
}
