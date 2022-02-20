using System.Text;
using Algorithms.Encoders.Interfaces;

namespace Algorithms.Encoders;

/// <summary>
/// Implements encoder using caesar cypher.
/// </summary>
public class CaesarEncoder : IEncoder<int>
{
    /// <summary>
    /// Encodes text using specified key.
    /// Time complexity: O(n), space complexity: O(n), where n - text length.
    /// </summary>
    /// <param name="data">Text to be encoded.</param>
    /// <param name="key">Key that will be used to encode the text.</param>
    /// <returns>Encoded text.</returns>
    public string Encode(string data, int key) => Cipher(data, key);

    /// <summary>
    /// Decodes text that was encoded using specified key.
    /// Time complexity: O(n), space complexity: O(n), where n - text length.
    /// </summary>
    /// <param name="data">Text to be decoded.</param>
    /// <param name="key">Key that was used to encode the text.</param>
    /// <returns>Decoded text.</returns>
    public string Decode(string data, int key) => Cipher(data, -key);

    private static string Cipher(string data, int key)
    {
        StringBuilder sb = new(data.Length);

        foreach (var item in data)
        {
            if (char.IsLetter(item) == false)
            {
                _ = sb.Append(item);
                continue;
            }

            var letterA = char.IsUpper(item) ? 'A' : 'a';
            var letterZ = char.IsUpper(item) ? 'Z' : 'z';

            var c = item + key;
            
            c -= c > letterZ ? 26 * (1 + (c - letterZ - 1) / 26) : 0;
            c += c < letterA ? 26 * (1 + (letterA - c - 1) / 26) : 0;

            _ = sb.Append((char)c);
        }

        return sb.ToString();
    }
}
