namespace Wingmann.Algorithms.Shufflers;

/// <summary>
/// Common interface of shuffle algorithms.
/// </summary>
public interface IShuffler
{
    /// <summary>
    /// Shuffles array.
    /// </summary>
    /// <param name="data">Array for shuffle.</param>
    /// <typeparam name="T">Type of data item.</typeparam>
    void Shuffle<T>(T[] data);
}
