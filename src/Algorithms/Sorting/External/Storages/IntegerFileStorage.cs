using Algorithms.Sorting.External.Interfaces;

namespace Algorithms.Sorting.External.Storages;

public class IntegerFileStorage : ISequentialStorage<int>
{
    private readonly string _filename;

    public IntegerFileStorage(string filename, int length)
    {
        Length = length;
        _filename = filename;
    }

    public int Length { get; }

    public ISequentialStorageReader<int> GetReader() => new FileReader(_filename);

    public ISequentialStorageWriter<int> GetWriter() => new FileWriter(_filename);

    private class FileReader : ISequentialStorageReader<int>
    {
        private readonly BinaryReader _reader;

        public FileReader(string filename) => _reader = new BinaryReader(File.OpenRead(filename));

        public void Dispose() => _reader.Dispose();

        public int Read() => _reader.ReadInt32();
    }

    private class FileWriter : ISequentialStorageWriter<int>
    {
        private readonly BinaryWriter _writer;

        public FileWriter(string filename) => _writer = new BinaryWriter(File.OpenWrite(filename));

        public void Write(int value) => _writer.Write(value);

        public void Dispose() => _writer.Dispose();
    }
}
