namespace Algorithms.Sorting.External.Interfaces;

public interface ISequentialStorageWriter<in T> : IDisposable
{
    void Write(T value);
}
