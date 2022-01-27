namespace Algorithms.Sorting.External.Interfaces;

public interface ISequentialStorage<T>
{
    public int Length { get; }

    ISequentialStorageReader<T> GetReader();

    ISequentialStorageWriter<T> GetWriter();
}
