namespace Wingmann.Algorithms.Sorting.External;

public interface ISequentialStorage<T>
{
    public int Length { get; }

    ISequentialStorageReader<T> GetReader();

    ISequentialStorageWriter<T> GetWriter();
}
