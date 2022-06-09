namespace Wingmann.Algorithms.Shufflers;

/// <summary>
/// Implements Fisher-Yates shuffle algorithm.
/// See on <see href="https://en.wikipedia.org/wiki/Fisher-Yates_shuffle">Wikipedia</see>
/// </summary>
public class FisherYatesShuffler : IShuffler
{
    /// <inheritdoc cref="IShuffler.Shuffle{T}"/>
    public void Shuffle<T>(T[] data)
    {
        Random random = new();

        for (var i = data.Length - 1; i > 0; i--)
        {
            var randomIndex = random.Next(0, i + 1);
            (data[i], data[randomIndex]) = (data[randomIndex], data[i]);
        }
    }
}
