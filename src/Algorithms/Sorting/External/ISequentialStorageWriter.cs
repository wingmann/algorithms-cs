namespace Wingmann.Algorithms.Sorting.External;

public interface ISequentialStorageWriter<in T> : IDisposable
{
    void Write(T value);
}
