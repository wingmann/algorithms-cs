using Algorithms.Sorting.External.Interfaces;

namespace Algorithms.Sorting.External.Storages;

public class IntegerInMemoryStorage : ISequentialStorage<int>
{
    private readonly int[] _storage;

    public IntegerInMemoryStorage(int[] array) => _storage = array;

    public int Length => _storage.Length;

    public ISequentialStorageReader<int> GetReader() => new InMemoryReader(_storage);

    public ISequentialStorageWriter<int> GetWriter() => new InMemoryWriter(_storage);

    private class InMemoryReader : ISequentialStorageReader<int>
    {
        private readonly int[] _storage;
        private int _offset;

        public InMemoryReader(int[] storage) => _storage = storage;

        public void Dispose()
        {
            // Nothing to dispose here
        }

        public int Read() => _storage[_offset++];
    }

    private class InMemoryWriter : ISequentialStorageWriter<int>
    {
        private readonly int[] _storage;
        private int _offset;

        public InMemoryWriter(int[] storage) => _storage = storage;

        public void Write(int value) => _storage[_offset++] = value;

        public void Dispose()
        {
        }
    }
}
