using System.Text;

namespace Algorithms.Encoders;

/// <summary>
/// Implements encoder using caesar cypher.<br />
/// See on <see href="https://en.wikipedia.org/wiki/Caesar_cipher">Wikipedia</see>.
/// </summary>
public class CaesarEncoder : IEncoder<int>
{
    /// <inheritdoc cref="IEncoder{TKey}.Encode"/>
    public string Encode(string data, int key) => Cipher(data, key);

    /// <inheritdoc cref="IEncoder{TKey}.Decode"/>
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
